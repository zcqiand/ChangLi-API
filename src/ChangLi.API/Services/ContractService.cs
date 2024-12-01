using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.Contract;
using ChangLi.Shared.DTO.PurchaseRequest;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 合同
/// </summary>
public class ContractService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ContractCreateInDto input)
    {
        var model = Mapper.Map<Contract>(input);

        model.Id = NewId.NextSequentialGuid();

        await CreateItems(input, model);

        await _dbContext.Contracts.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ContractUpdateInDto input)
    {
        var model = await _dbContext.Contracts.Include(x => x.Items).SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await UpdateItems(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    private async Task CreateItems(ContractCreateInDto input, Contract model)
    {
        model.Items.Clear();

        foreach (var item in input.Items)
        {
            var goods = await _dbContext.Goods.FirstOrDefaultAsync(x => x.Name.Equals(item.Name) && x.BrandModel.Equals(item.BrandModel));
            if (goods == null)
            {
                goods = new Goods
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = item.Name,
                    BrandModel = item.BrandModel
                };

                await _dbContext.Goods.AddAsync(goods);
            }
            var contractItem = new ContractItem
            {
                Id = NewId.NextSequentialGuid(),
                GoodsId = goods.Id,
                Goods = goods,
                ContractId = model.Id,
                Contract = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(contractItem);
        }
    }

    private async Task UpdateItems(ContractUpdateInDto input, Contract model)
    {
        model.Items.Clear();

        foreach (var item in input.Items)
        {
            var goods = await _dbContext.Goods.FirstOrDefaultAsync(x => x.Name.Equals(item.Name) && x.BrandModel.Equals(item.BrandModel));
            if (goods == null)
            {
                goods = new Goods
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = item.Name,
                    BrandModel = item.BrandModel
                };

                await _dbContext.Goods.AddAsync(goods);
            }

            var contractItem = new ContractItem
            {
                Id = NewId.NextSequentialGuid(),
                Goods = goods,
                GoodsId = goods.Id,
                ContractId = model.Id,
                Contract = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(contractItem);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(ContractDeleteInDto input)
    {
        var model = await _dbContext.Contracts.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Contracts.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ContractBatchDeleteInDto input)
    {
        var model = await _dbContext.Contracts.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Contracts.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<ContractQueryOutDto>> Query(ContractQueryInDto input)
    {
        var query = from a in _dbContext.Contracts.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ContractQueryOutDto>>(items);

        return new PagingOutBase<ContractQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ContractGetOutDto> Get(ContractGetInDto input)
    {
        var query = from a in _dbContext.Contracts.Include(x => x.Items).ThenInclude(x => x.Goods).AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ContractGetOutDto>(items);
    }
}
