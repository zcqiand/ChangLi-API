using ChangLi.Shared.Models;

namespace ChangLi.Shared.DTO.PurchaseRequest;

/// <summary>
/// 采购需求
/// </summary>
public class PurchaseRequestCreateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 需求编号
    /// </summary>
    public string? RequestNumber { get; set; }
    /// <summary>
    /// 需求日期
    /// </summary>
    public System.DateTimeOffset RequestDate { get; set; }
    /// <summary>
    /// 采购标题
    /// </summary>
    public string PurchaseTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 需求清单
    /// </summary>
    public IList<PurchaseRequestItemModel> Items { get; set; } = new List<PurchaseRequestItemModel>();
}
