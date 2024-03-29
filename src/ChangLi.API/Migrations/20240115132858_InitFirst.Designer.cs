﻿// <auto-generated />
using System;
using ChangLi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ChangLi.API.Migrations
{
    [DbContext(typeof(ChangLiDbContext))]
    [Migration("20240115132858_InitFirst")]
    partial class InitFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ChangLi.Domain.Model.BusinessEnterprise", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("企业类别标识");

                    b.Property<string>("ContactAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系地址");

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系人");

                    b.Property<string>("ContactTel")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("联系电话");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<int>("EnterpriseType")
                        .HasColumnType("int")
                        .HasComment("企业类型");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("企业全称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("企业简称");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("BusinessEnterprise");

                    b.HasComment("业务企业");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.BusinessEnterpriseCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("类别编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("类别名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("BusinessEnterpriseCategory");

                    b.HasComment("供应商类别");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("ContractDate")
                        .HasColumnType("datetimeoffset")
                        .HasComment("合同日期");

                    b.Property<string>("ContractNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("合同编号");

                    b.Property<string>("ContractTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("合同标题");

                    b.Property<int>("ContractType")
                        .HasColumnType("int")
                        .HasComment("合同类型");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("PartyA")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("甲方");

                    b.Property<string>("PartyB")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("乙方");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("Contract");

                    b.HasComment("合同");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ContractItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("合同标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("GoodsId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("物品标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("数量");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("总价");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("单价");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("GoodsId");

                    b.ToTable("ContractItem");

                    b.HasComment("合同清单");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Goods", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("BrandModel")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("品牌型号");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("物品类别标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("物品名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Goods");

                    b.HasComment("物品");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.GoodsCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("类别编号");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("类别名称");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.HasKey("Id");

                    b.ToTable("GoodsCategory");

                    b.HasComment("物品类别");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.PurchaseRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("PurchaseTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("采购标题");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<DateTimeOffset>("RequestDate")
                        .HasColumnType("datetimeoffset")
                        .HasComment("需求日期");

                    b.Property<string>("RequestNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("需求编号");

                    b.HasKey("Id");

                    b.ToTable("PurchaseRequest");

                    b.HasComment("采购需求");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.PurchaseRequestItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("GoodsId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("物品标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("PurchaseRequestId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("采购需求标识");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("数量");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("总价");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("单价");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("PurchaseRequestId");

                    b.ToTable("PurchaseRequestItem");

                    b.HasComment("采购需求清单");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ReturnGoods", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<DateTimeOffset>("ReturnGoodsDate")
                        .HasColumnType("datetimeoffset")
                        .HasComment("退货日期");

                    b.Property<string>("ReturnGoodsNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("退货编号");

                    b.Property<string>("ReturnGoodsTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("退货标题");

                    b.Property<int>("ReturnGoodsType")
                        .HasColumnType("int")
                        .HasComment("退货类型");

                    b.HasKey("Id");

                    b.ToTable("ReturnGoods");

                    b.HasComment("退货");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ReturnGoodsItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("GoodsId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("物品标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("数量");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<Guid>("ReturnGoodsId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("退货标识");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("总价");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("单价");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("ReturnGoodsId");

                    b.ToTable("ReturnGoodsItem");

                    b.HasComment("退货清单");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Stock", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<DateTimeOffset>("StockDate")
                        .HasColumnType("datetimeoffset")
                        .HasComment("库存日期");

                    b.Property<string>("StockNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("库存编号");

                    b.Property<string>("StockTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("库存标题");

                    b.Property<int>("StockType")
                        .HasColumnType("int")
                        .HasComment("库存类型");

                    b.HasKey("Id");

                    b.ToTable("Stock");

                    b.HasComment("库存");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.StockItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid>("GoodsId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("物品标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("数量");

                    b.Property<string>("Remark")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("备注");

                    b.Property<Guid>("StockId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("库存标识");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("总价");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("单价");

                    b.HasKey("Id");

                    b.HasIndex("GoodsId");

                    b.HasIndex("StockId");

                    b.ToTable("StockItem");

                    b.HasComment("库存清单");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.BusinessEnterprise", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.BusinessEnterpriseCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ContractItem", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.Contract", "Contract")
                        .WithMany("Items")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChangLi.Domain.Model.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");

                    b.Navigation("Goods");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Goods", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.GoodsCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.PurchaseRequestItem", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChangLi.Domain.Model.PurchaseRequest", "PurchaseRequest")
                        .WithMany("Items")
                        .HasForeignKey("PurchaseRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("PurchaseRequest");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ReturnGoodsItem", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChangLi.Domain.Model.ReturnGoods", "ReturnGoods")
                        .WithMany("Items")
                        .HasForeignKey("ReturnGoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("ReturnGoods");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.StockItem", b =>
                {
                    b.HasOne("ChangLi.Domain.Model.Goods", "Goods")
                        .WithMany()
                        .HasForeignKey("GoodsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChangLi.Domain.Model.Stock", "Stock")
                        .WithMany("Items")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Goods");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Contract", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.PurchaseRequest", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.ReturnGoods", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("ChangLi.Domain.Model.Stock", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
