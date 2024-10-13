namespace ChangLi.Shared.DTO.BusinessEnterprise;

/// <summary>
/// 业务企业
/// </summary>
public class BusinessEnterpriseBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

