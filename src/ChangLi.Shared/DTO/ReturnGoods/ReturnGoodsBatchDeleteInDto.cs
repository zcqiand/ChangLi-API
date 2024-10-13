namespace ChangLi.Shared.DTO.ReturnGoods;

/// <summary>
/// 退货
/// </summary>
public class ReturnGoodsBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

