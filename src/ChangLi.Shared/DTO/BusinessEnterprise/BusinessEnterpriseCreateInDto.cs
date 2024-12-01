namespace ChangLi.Shared.DTO.BusinessEnterprise;

/// <summary>
/// 业务企业
/// </summary>
public class BusinessEnterpriseCreateInDto : CreateInBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 企业类型
    /// </summary>
    public int EnterpriseType { get; set; }
    /// <summary>
    /// 企业全称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 企业简称
    /// </summary>
    public string ShortName { get; set; } = null!;
    /// <summary>
    /// 企业类别标识
    /// </summary>
    public Guid? CategoryId { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    public string? ContactTel { get; set; }
    /// <summary>
    /// 联系地址
    /// </summary>
    public string? ContactAddress { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}
