namespace ChangLi.Shared.DTO.GoodsCategory;

/// <summary>
/// 物品类别
/// </summary>
public class GoodsCategoryBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

