namespace ChangLi.Shared.DTO.GoodsCategory;

/// <summary>
/// 物品类别
/// </summary>
public class GoodsCategoryGetOutDto : GetOutBase
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
}

