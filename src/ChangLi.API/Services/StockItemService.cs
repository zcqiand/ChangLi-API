using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.StockItem;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 库存清单
/// </summary>
public class StockItemService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public StockItemService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(StockItemCreateInDto input)
    {
        var model = Mapper.Map<StockItem>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.StockItems.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(StockItemUpdateInDto input)
    {
        var model = await _dbContext.StockItems.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(StockItemDeleteInDto input)
    {
        var model = await _dbContext.StockItems.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.StockItems.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(StockItemBatchDeleteInDto input)
    {
        var model = await _dbContext.StockItems.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.StockItems.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<StockItemQueryOutDto>> Query(StockItemQueryInDto input)
    {
        var query = from a in _dbContext.StockItems.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<StockItemQueryOutDto>>(items);

        return new PagingOutBase<StockItemQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<StockItemGetOutDto> Get(StockItemGetInDto input)
    {
        var query = from a in _dbContext.StockItems.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<StockItemGetOutDto>(items);
    }
}
