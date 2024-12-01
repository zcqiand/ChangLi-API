using ChangLi.HostApp.Services;
using ChangLi.Shared.DTO.BusinessEnterpriseCategory;

namespace ChangLi.HostApp.Controllers;

/// <summary>
/// 供应商类别
/// </summary>
[Area("Erp")]
public class BusinessEnterpriseCategoryController : AppControllerBase
{
    private readonly BusinessEnterpriseCategoryService _service;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    /// <param name="service"></param>
    public BusinessEnterpriseCategoryController(IServiceProvider serviceProvider, BusinessEnterpriseCategoryService service) :
        base(serviceProvider)
    {
        _service = service;
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<Guid>> Create(BusinessEnterpriseCategoryCreateInDto input)
    {
        var result = await _service.Create(input);
        return Success(result);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Update(BusinessEnterpriseCategoryUpdateInDto input)
    {
        var result = await _service.Update(input);
        return Success(result);
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> Delete(BusinessEnterpriseCategoryDeleteInDto input)
    {
        var result = await _service.Delete(input);
        return Success(result);
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ApiResult<bool>> BatchDelete(BusinessEnterpriseCategoryBatchDeleteInDto input)
    {
        var result = await _service.BatchDelete(input);
        return Success(result);
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<PagingOutBase<BusinessEnterpriseCategoryQueryOutDto>>> Query([FromQuery] BusinessEnterpriseCategoryQueryInDto input)
    {
        var result = await _service.Query(input);
        return Success(result);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<ApiResult<BusinessEnterpriseCategoryGetOutDto>> Get([FromQuery] BusinessEnterpriseCategoryGetInDto input)
    {
        var result = await _service.Get(input);
        return Success(result);
    }
}