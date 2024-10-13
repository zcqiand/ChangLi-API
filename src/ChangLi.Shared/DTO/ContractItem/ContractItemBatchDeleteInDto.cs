namespace ChangLi.Shared.DTO.ContractItem;

/// <summary>
/// 合同清单
/// </summary>
public class ContractItemBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

