using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.Goods;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 物品
/// </summary>
public class GoodsService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public GoodsService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(GoodsCreateInDto input)
    {
        var model = Mapper.Map<Goods>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.Goods.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(GoodsUpdateInDto input)
    {
        var model = await _dbContext.Goods.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(GoodsDeleteInDto input)
    {
        var model = await _dbContext.Goods.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Goods.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(GoodsBatchDeleteInDto input)
    {
        var model = await _dbContext.Goods.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Goods.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOut<GoodsQueryOutDto>> Query(GoodsQueryInDto input)
    {
        var query = from a in _dbContext.Goods.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<GoodsQueryOutDto>>(items);

        return new PagingOut<GoodsQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<GoodsGetOutDto> Get(GoodsGetInDto input)
    {
        var query = from a in _dbContext.Goods.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<GoodsGetOutDto>(items);
    }
}
