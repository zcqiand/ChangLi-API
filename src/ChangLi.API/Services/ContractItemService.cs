using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.ContractItem;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 合同清单
/// </summary>
public class ContractItemService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public ContractItemService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(ContractItemCreateInDto input)
    {
        var model = Mapper.Map<ContractItem>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.ContractItems.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(ContractItemUpdateInDto input)
    {
        var model = await _dbContext.ContractItems.SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(ContractItemDeleteInDto input)
    {
        var model = await _dbContext.ContractItems.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.ContractItems.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(ContractItemBatchDeleteInDto input)
    {
        var model = await _dbContext.ContractItems.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.ContractItems.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<ContractItemQueryOutDto>> Query(ContractItemQueryInDto input)
    {
        var query = from a in _dbContext.ContractItems.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<ContractItemQueryOutDto>>(items);

        return new PagingOut<ContractItemQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<ContractItemGetOutDto> Get(ContractItemGetInDto input)
    {
        var query = from a in _dbContext.ContractItems.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<ContractItemGetOutDto>(items);
    }
}
