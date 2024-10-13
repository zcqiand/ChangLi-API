namespace ChangLi.Shared.DTO.PurchaseRequest;

/// <summary>
/// 采购需求
/// </summary>
public class PurchaseRequestBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

