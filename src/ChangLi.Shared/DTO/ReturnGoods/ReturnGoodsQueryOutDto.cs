namespace ChangLi.Shared.DTO.ReturnGoods;

/// <summary>
/// 退货
/// </summary>
public class ReturnGoodsQueryOutDto
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
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}

