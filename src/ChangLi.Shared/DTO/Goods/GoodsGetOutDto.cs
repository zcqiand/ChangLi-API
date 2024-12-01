namespace ChangLi.Shared.DTO.Goods;

/// <summary>
/// 物品
/// </summary>
public class GoodsGetOutDto : GetOutBase
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
}

