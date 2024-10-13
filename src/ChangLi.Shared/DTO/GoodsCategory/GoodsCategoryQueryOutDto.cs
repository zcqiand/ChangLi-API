namespace ChangLi.Shared.DTO.GoodsCategory;

/// <summary>
/// 物品类别
/// </summary>
public class GoodsCategoryQueryOutDto
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

