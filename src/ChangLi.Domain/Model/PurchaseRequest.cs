using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 采购需求
/// </summary>
[Table("PurchaseRequest")]
[Comment("采购需求")]
public partial class PurchaseRequest : Entity
{
    /// <summary>
    /// 需求编号
    /// </summary>
    [StringLength(50)]
    [Comment("需求编号")]
    public string? RequestNumber { get; set; }
    /// <summary>
    /// 需求日期
    /// </summary>
    [Comment("需求日期")]
    public DateTimeOffset RequestDate { get; set; }
    /// <summary>
    /// 采购标题
    /// </summary>
    [StringLength(200)]
    [Comment("采购标题")]
    public string PurchaseTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 采购需求清单
    /// </summary>
    public ICollection<PurchaseRequestItem> Items { get; set; } = new List<PurchaseRequestItem>();
}