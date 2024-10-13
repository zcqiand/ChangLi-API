namespace ChangLi.Shared.DTO.Stock;

/// <summary>
/// 库存
/// </summary>
public class StockQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 库存类型
    /// </summary>
    public int StockType { get; set; }
    /// <summary>
    /// 库存编号
    /// </summary>
    public string? StockNumber { get; set; }
    /// <summary>
    /// 库存日期
    /// </summary>
    public System.DateTimeOffset StockDate { get; set; }
    /// <summary>
    /// 库存标题
    /// </summary>
    public string StockTitle { get; set; } = null!;
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

