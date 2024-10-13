namespace ChangLi.Shared.DTO.Contract;

/// <summary>
/// 合同
/// </summary>
public class ContractBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

