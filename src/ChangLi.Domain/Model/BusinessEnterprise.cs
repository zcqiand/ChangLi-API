using ChangLi.Shared.Enums;
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 业务企业
/// </summary>
[Table("BusinessEnterprise")]
[Comment("业务企业")]
public partial class BusinessEnterprise : Entity
{
    /// <summary>
    /// 企业类型
    /// </summary>
    [Comment("企业类型")]
    public EnterpriseType EnterpriseType { get; set; }
    /// <summary>
    /// 企业全称
    /// </summary>
    [StringLength(200)]
    [Comment("企业全称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 企业简称
    /// </summary>
    [StringLength(200)]
    [Comment("企业简称")]
    public string ShortName { get; set; } = null!;
    /// <summary>
    /// 企业类别
    /// </summary>
    [Comment("企业类别标识")]
    public Guid? CategoryId { get; set; }
    public BusinessEnterpriseCategory? Category { get; set; }
    /// <summary>
    /// 联系人
    /// </summary>
    [StringLength(200)]
    [Comment("联系人")]
    public string? ContactPerson { get; set; }
    /// <summary>
    /// 联系电话
    /// </summary>
    [StringLength(200)]
    [Comment("联系电话")]
    public string? ContactTel { get; set; }
    /// <summary>
    /// 联系地址
    /// </summary>
    [StringLength(200)]
    [Comment("联系地址")]
    public string? ContactAddress { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
}