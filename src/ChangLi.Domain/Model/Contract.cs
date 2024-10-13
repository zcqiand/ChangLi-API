using ChangLi.Shared.Enums;
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 合同
/// </summary>
[Table("Contract")]
[Comment("合同")]
public partial class Contract : Entity
{
    /// <summary>
    /// 合同类型
    /// </summary>
    [Comment("合同类型")]
    public ContractType ContractType { get; set; }
    /// <summary>
    /// 合同编号
    /// </summary>
    [StringLength(50)]
    [Comment("合同编号")]
    public string? ContractNumber { get; set; }
    /// <summary>
    /// 合同日期
    /// </summary>
    [Comment("合同日期")]
    public DateTimeOffset ContractDate { get; set; }
    /// <summary>
    /// 合同标题
    /// </summary>
    [StringLength(200)]
    [Comment("合同标题")]
    public string ContractTitle { get; set; } = null!;
    /// <summary>
    /// 甲方
    /// </summary>
    [StringLength(200)]
    [Comment("甲方")]
    public string PartyA { get; set; } = null!;
    /// <summary>
    /// 乙方
    /// </summary>
    [StringLength(200)]
    [Comment("乙方")]
    public string PartyB { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 合同清单
    /// </summary>
    public ICollection<ContractItem> Items { get; set; } = new List<ContractItem>();
}