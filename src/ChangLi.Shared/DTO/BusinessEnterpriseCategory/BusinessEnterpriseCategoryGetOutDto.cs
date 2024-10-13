namespace ChangLi.Shared.DTO.BusinessEnterpriseCategory;

/// <summary>
/// 供应商类别
/// </summary>
public class BusinessEnterpriseCategoryGetOutDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 类别编号
    /// </summary>
    public string Code { get; set; } = null!;
    /// <summary>
    /// 类别名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}

