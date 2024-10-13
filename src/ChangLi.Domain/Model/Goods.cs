using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 物品
/// </summary>
[Table("Goods")]
[Comment("物品")]
public partial class Goods : Entity
{
    /// <summary>
    /// 物品名称
    /// </summary>
    [StringLength(200)]
    [Comment("物品名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 物品类别
    /// </summary>
    public GoodsCategory? Category { get; set; }
    [Comment("物品类别标识")]
    public Guid? CategoryId { get; set; }
    /// <summary>
    /// 品牌型号
    /// </summary>
    [StringLength(200)]
    [Comment("品牌型号")]
    public string BrandModel { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
}