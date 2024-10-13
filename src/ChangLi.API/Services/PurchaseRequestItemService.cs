using ChangLi.Infrastructure;
using ChangLi.Shared.Models;
using ChangLi.Shared.DTO.PurchaseRequestItem;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 采购需求清单
/// </summary>
public class PurchaseRequestItemService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public PurchaseRequestItemService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(PurchaseRequestItemModel input)
    {
        var model = Mapper.Map<PurchaseRequestItem>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.PurchaseRequestItems.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(PurchaseRequestItemUpdateInDto input)
    {
        var model = await _dbContext.PurchaseRequestItems.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(PurchaseRequestItemDeleteInDto input)
    {
        var model = await _dbContext.PurchaseRequestItems.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.PurchaseRequestItems.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(PurchaseRequestItemBatchDeleteInDto input)
    {
        var model = await _dbContext.PurchaseRequestItems.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.PurchaseRequestItems.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<PurchaseRequestItemQueryOutDto>> Query(PurchaseRequestItemQueryInDto input)
    {
        var query = from a in _dbContext.PurchaseRequestItems.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<PurchaseRequestItemQueryOutDto>>(items);

        return new PagingOut<PurchaseRequestItemQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PurchaseRequestItemGetOutDto> Get(PurchaseRequestItemGetInDto input)
    {
        var query = from a in _dbContext.PurchaseRequestItems.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<PurchaseRequestItemGetOutDto>(items);
    }
}
