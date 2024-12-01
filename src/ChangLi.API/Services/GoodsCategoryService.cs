using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.GoodsCategory;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 物品类别
/// </summary>
public class GoodsCategoryService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public GoodsCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(GoodsCategoryCreateInDto input)
    {
        var model = Mapper.Map<GoodsCategory>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.GoodsCategories.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(GoodsCategoryUpdateInDto input)
    {
        var model = await _dbContext.GoodsCategories.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(GoodsCategoryDeleteInDto input)
    {
        var model = await _dbContext.GoodsCategories.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.GoodsCategories.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(GoodsCategoryBatchDeleteInDto input)
    {
        var model = await _dbContext.GoodsCategories.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.GoodsCategories.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<GoodsCategoryQueryOutDto>> Query(GoodsCategoryQueryInDto input)
    {
        var query = from a in _dbContext.GoodsCategories.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<GoodsCategoryQueryOutDto>>(items);

        return new PagingOutBase<GoodsCategoryQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<GoodsCategoryGetOutDto> Get(GoodsCategoryGetInDto input)
    {
        var query = from a in _dbContext.GoodsCategories.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<GoodsCategoryGetOutDto>(items);
    }
}
