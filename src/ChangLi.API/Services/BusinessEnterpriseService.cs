using ChangLi.Shared.DTO.BusinessEnterprise;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 业务企业
/// </summary>
public class BusinessEnterpriseService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public BusinessEnterpriseService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(BusinessEnterpriseCreateInDto input)
    {
        var model = Mapper.Map<BusinessEnterprise>(input);
        
        model.Id = NewId.NextSequentialGuid();
        
        await _dbContext.BusinessEnterprises.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(BusinessEnterpriseUpdateInDto input)
    {
        var model = await _dbContext.BusinessEnterprises.SingleAsync(x => x.Id.Equals(input.Id));

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
    public async Task<bool> Delete(BusinessEnterpriseDeleteInDto input)
    {
        var model = await _dbContext.BusinessEnterprises.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.BusinessEnterprises.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(BusinessEnterpriseBatchDeleteInDto input)
    {
        var model = await _dbContext.BusinessEnterprises.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.BusinessEnterprises.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<BusinessEnterpriseQueryOutDto>> Query(BusinessEnterpriseQueryInDto input)
    {
        var query = from a in _dbContext.BusinessEnterprises.AsNoTracking()
                    orderby a.Id
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<BusinessEnterpriseQueryOutDto>>(items);

        return new PagingOutBase<BusinessEnterpriseQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<BusinessEnterpriseGetOutDto> Get(BusinessEnterpriseGetInDto input)
    {
        var query = from a in _dbContext.BusinessEnterprises.AsNoTracking()
                    orderby a.Id
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<BusinessEnterpriseGetOutDto>(items);
    }
}
