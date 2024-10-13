namespace ChangLi.Shared.DTO.Goods;

/// <summary>
/// 物品
/// </summary>
public class GoodsQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// 物品类别标识
    /// </summary>
    public Guid? CategoryId { get; set; }
    /// <summary>
    /// 品牌型号
    /// </summary>
    public string? BrandModel { get; set; }
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

