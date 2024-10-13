namespace ChangLi.Shared.DTO.Stock;

/// <summary>
/// 库存
/// </summary>
public class StockBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

