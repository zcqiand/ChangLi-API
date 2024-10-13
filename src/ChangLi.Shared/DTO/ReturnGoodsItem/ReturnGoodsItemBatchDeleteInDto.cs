namespace ChangLi.Shared.DTO.ReturnGoodsItem;

/// <summary>
/// 退货清单
/// </summary>
public class ReturnGoodsItemBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

