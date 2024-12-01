using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.ReturnGoods;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 退货
/// </summary>
public class ReturnGoodsService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ReturnGoodsService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ReturnGoodsCreateInDto input)
    {
        var model = Mapper.Map<ReturnGoods>(input);
        
        model.Id = NewId.NextSequentialGuid();

        await CreateItems(input, model);

        await _dbContext.ReturnGoods.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ReturnGoodsUpdateInDto input)
    {
        var model = await _dbContext.ReturnGoods.Include(x => x.Items).ThenInclude(x => x.Goods).SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await UpdateItems(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }



    private async Task CreateItems(ReturnGoodsCreateInDto input, ReturnGoods model)
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
            var returnGoodsItem = new ReturnGoodsItem
            {
                Id = NewId.NextSequentialGuid(),
                GoodsId = goods.Id,
                Goods = goods,
                ReturnGoodsId = model.Id,
                ReturnGoods = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(returnGoodsItem);
        }
    }

    private async Task UpdateItems(ReturnGoodsUpdateInDto input, ReturnGoods model)
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

            var returnGoodsItem = new ReturnGoodsItem
            {
                Id = NewId.NextSequentialGuid(),
                Goods = goods,
                GoodsId = goods.Id,
                ReturnGoodsId = model.Id,
                ReturnGoods = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(returnGoodsItem);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(ReturnGoodsDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoods.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ReturnGoods.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ReturnGoodsBatchDeleteInDto input)
    {
        var model = await _dbContext.ReturnGoods.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ReturnGoods.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<ReturnGoodsQueryOutDto>> Query(ReturnGoodsQueryInDto input)
    {
        var query = from a in _dbContext.ReturnGoods.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ReturnGoodsQueryOutDto>>(items);

        return new PagingOutBase<ReturnGoodsQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ReturnGoodsGetOutDto> Get(ReturnGoodsGetInDto input)
    {
        var query = from a in _dbContext.ReturnGoods.Include(x => x.Items).ThenInclude(x => x.Goods).AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ReturnGoodsGetOutDto>(items);
    }
}
