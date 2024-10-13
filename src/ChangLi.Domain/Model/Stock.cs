using ChangLi.Shared.Enums;
using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 库存
/// </summary>
[Table("Stock")]
[Comment("库存")]
public partial class Stock : Entity
{
    /// <summary>
    /// 库存类型
    /// </summary>
    [Comment("库存类型")]
    public StockType StockType { get; set; }
    /// <summary>
    /// 库存编号
    /// </summary>
    [StringLength(50)]
    [Comment("库存编号")]
    public string? StockNumber { get; set; }
    /// <summary>
    /// 库存日期
    /// </summary>
    [Comment("库存日期")]
    public DateTimeOffset StockDate { get; set; }
    /// <summary>
    /// 库存标题
    /// </summary>
    [StringLength(200)]
    [Comment("库存标题")]
    public string StockTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
    /// <summary>
    /// 库存清单
    /// </summary>
    public ICollection<StockItem> Items { get; set; } = new List<StockItem>();
}