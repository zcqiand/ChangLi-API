namespace ChangLi.Shared.DTO.Goods;

/// <summary>
/// 物品
/// </summary>
public class GoodsBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

