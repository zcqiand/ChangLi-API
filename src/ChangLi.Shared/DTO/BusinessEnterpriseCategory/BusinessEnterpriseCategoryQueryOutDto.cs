namespace ChangLi.Shared.DTO.BusinessEnterpriseCategory;

/// <summary>
/// 供应商类别
/// </summary>
public class BusinessEnterpriseCategoryQueryOutDto
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
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}

