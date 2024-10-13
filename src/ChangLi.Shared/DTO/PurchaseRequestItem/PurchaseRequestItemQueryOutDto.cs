namespace ChangLi.Shared.DTO.PurchaseRequestItem;

/// <summary>
/// 采购需求清单
/// </summary>
public class PurchaseRequestItemQueryOutDto
{
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
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}

