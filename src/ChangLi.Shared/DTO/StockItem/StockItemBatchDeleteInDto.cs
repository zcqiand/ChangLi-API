namespace ChangLi.Shared.DTO.StockItem;

/// <summary>
/// 库存清单
/// </summary>
public class StockItemBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

