using CommonMormon.Infrastructure.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChangLi.Domain.Model;

/// <summary>
/// 物品类别
/// </summary>
[Table("GoodsCategory")]
[Comment("物品类别")]
public partial class GoodsCategory : Entity
{
    /// <summary>
    /// 类别编号
    /// </summary>
    [StringLength(50)]
    [Comment("类别编号")]
    public string Code { get; set; } = null!;
    /// <summary>
    /// 类别名称
    /// </summary>
    [StringLength(200)]
    [Comment("类别名称")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    [StringLength(2000)]
    [Comment("备注")]
    public string? Remark { get; set; }
}