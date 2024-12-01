namespace ChangLi.Shared.DTO.ReturnGoodsItem;

/// <summary>
/// 退货清单
/// </summary>
public class ReturnGoodsItemGetOutDto : GetOutBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 退货标识
    /// </summary>
    public Guid ReturnGoodsId { get; set; }
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

