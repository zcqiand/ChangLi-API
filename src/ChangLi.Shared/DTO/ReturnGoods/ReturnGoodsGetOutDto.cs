using ChangLi.Shared.Models;

namespace ChangLi.Shared.DTO.ReturnGoods;

/// <summary>
/// 退货
/// </summary>
public class ReturnGoodsGetOutDto : GetOutBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 退货类型
    /// </summary>
    public int ReturnGoodsType { get; set; }
    /// <summary>
    /// 退货编号
    /// </summary>
    public string? ReturnGoodsNumber { get; set; }
    /// <summary>
    /// 退货日期
    /// </summary>
    public System.DateTimeOffset ReturnGoodsDate { get; set; }
    /// <summary>
    /// 退货标题
    /// </summary>
    public string ReturnGoodsTitle { get; set; } = null!;
    /// <summary>
    /// 备注
    /// </summary>
    public string? Remark { get; set; }
    /// <summary>
    /// 退货清单
    /// </summary>
    public IList<ReturnGoodsItemModel> Items { get; set; } = new List<ReturnGoodsItemModel>();
}

