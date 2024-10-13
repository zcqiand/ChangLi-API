namespace ChangLi.Shared.DTO.BusinessEnterpriseCategory;

/// <summary>
/// 供应商类别
/// </summary>
public class BusinessEnterpriseCategoryBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

