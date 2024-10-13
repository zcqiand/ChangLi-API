namespace ChangLi.Shared.DTO.PurchaseRequestItem;

/// <summary>
/// 采购需求清单
/// </summary>
public class PurchaseRequestItemCreateInDto : DtoBase
{
    public PurchaseRequestItemCreateInDto()
    {
    }

    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 采购需求标识
    /// </summary>
    public Guid PurchaseRequestId { get; set; }
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
