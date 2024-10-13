namespace ChangLi.Shared.DTO.ContractItem;

/// <summary>
/// 合同清单
/// </summary>
public class ContractItemUpdateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 合同标识
    /// </summary>
    public Guid ContractId { get; set; }
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

