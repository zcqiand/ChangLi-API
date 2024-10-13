namespace ChangLi.Shared.DTO.StockItem;

/// <summary>
/// 库存清单
/// </summary>
public class StockItemUpdateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 库存标识
    /// </summary>
    public Guid StockId { get; set; }
    /// <summary>
    /// 物品标识
    /// </summary>
    public Guid GoodsId { get; set; }
    /// <summary>
    /// 数量
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// 单价
    /// </summary>
    public decimal UnitPrice { get; set; }
    /// <summary>
    /// 总价
    /// </summary>
    public decimal TotalPrice { get; set; }
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
}

