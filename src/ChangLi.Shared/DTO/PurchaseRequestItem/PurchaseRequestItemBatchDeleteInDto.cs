namespace ChangLi.Shared.DTO.PurchaseRequestItem;

/// <summary>
/// 采购需求清单
/// </summary>
public class PurchaseRequestItemBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

