using ChangLi.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ChangLi.Infrastructure;

public partial class ChangLiDbContext : DbContext
{
    public ChangLiDbContext(DbContextOptions<ChangLiDbContext> options)
        : base(options)
    {
    }

    #region 实体
    public virtual DbSet<BusinessEnterprise> BusinessEnterprises { get; set; } = null!;
    public virtual DbSet<BusinessEnterpriseCategory> BusinessEnterpriseCategories { get; set; } = null!;
    public virtual DbSet<Contract> Contracts { get; set; } = null!;
    public virtual DbSet<ContractItem> ContractItems { get; set; } = null!;
    public virtual DbSet<Goods> Goods { get; set; } = null!;
    public virtual DbSet<GoodsCategory> GoodsCategories { get; set; } = null!;
    public virtual DbSet<PurchaseRequest> PurchaseRequests { get; set; } = null!;
    public virtual DbSet<PurchaseRequestItem> PurchaseRequestItems { get; set; } = null!;
    public virtual DbSet<ReturnGoods> ReturnGoods { get; set; } = null!;
    public virtual DbSet<ReturnGoodsItem> ReturnGoodsItems { get; set; } = null!;
    public virtual DbSet<Stock> Stocks { get; set; } = null!;
    public virtual DbSet<StockItem> StockItems { get; set; } = null!;
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}