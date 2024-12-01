using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.BusinessEnterpriseCategory;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 供应商类别
/// </summary>
public class BusinessEnterpriseCategoryService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public BusinessEnterpriseCategoryService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(BusinessEnterpriseCategoryCreateInDto input)
    {
        var model = Mapper.Map<BusinessEnterpriseCategory>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.BusinessEnterpriseCategories.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(BusinessEnterpriseCategoryUpdateInDto input)
    {
        var model = await _dbContext.BusinessEnterpriseCategories.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(BusinessEnterpriseCategoryDeleteInDto input)
    {
        var model = await _dbContext.BusinessEnterpriseCategories.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.BusinessEnterpriseCategories.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(BusinessEnterpriseCategoryBatchDeleteInDto input)
    {
        var model = await _dbContext.BusinessEnterpriseCategories.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.BusinessEnterpriseCategories.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<BusinessEnterpriseCategoryQueryOutDto>> Query(BusinessEnterpriseCategoryQueryInDto input)
    {
        var query = from a in _dbContext.BusinessEnterpriseCategories.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<BusinessEnterpriseCategoryQueryOutDto>>(items);

        return new PagingOutBase<BusinessEnterpriseCategoryQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<BusinessEnterpriseCategoryGetOutDto> Get(BusinessEnterpriseCategoryGetInDto input)
    {
        var query = from a in _dbContext.BusinessEnterpriseCategories.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<BusinessEnterpriseCategoryGetOutDto>(items);
    }
}
