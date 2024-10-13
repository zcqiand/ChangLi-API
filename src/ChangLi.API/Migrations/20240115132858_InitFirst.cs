using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChangLi.API.Migrations
{
    public partial class InitFirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessEnterpriseCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "类别编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "类别名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEnterpriseCategory", x => x.Id);
                },
                comment: "供应商类别");

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    ContractType = table.Column<int>(type: "int", nullable: false, comment: "合同类型"),
                    ContractNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "合同编号"),
                    ContractDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "合同日期"),
                    ContractTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "合同标题"),
                    PartyA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "甲方"),
                    PartyB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "乙方"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                },
                comment: "合同");

            migrationBuilder.CreateTable(
                name: "GoodsCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "类别编号"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "类别名称"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodsCategory", x => x.Id);
                },
                comment: "物品类别");

            migrationBuilder.CreateTable(
                name: "PurchaseRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    RequestNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "需求编号"),
                    RequestDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "需求日期"),
                    PurchaseTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "采购标题"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequest", x => x.Id);
                },
                comment: "采购需求");

            migrationBuilder.CreateTable(
                name: "ReturnGoods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    ReturnGoodsType = table.Column<int>(type: "int", nullable: false, comment: "退货类型"),
                    ReturnGoodsNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "退货编号"),
                    ReturnGoodsDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "退货日期"),
                    ReturnGoodsTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "退货标题"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnGoods", x => x.Id);
                },
                comment: "退货");

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    StockType = table.Column<int>(type: "int", nullable: false, comment: "库存类型"),
                    StockNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true, comment: "库存编号"),
                    StockDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "库存日期"),
                    StockTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "库存标题"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                },
                comment: "库存");

            migrationBuilder.CreateTable(
                name: "BusinessEnterprise",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    EnterpriseType = table.Column<int>(type: "int", nullable: false, comment: "企业类型"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "企业全称"),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "企业简称"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "企业类别标识"),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系人"),
                    ContactTel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系电话"),
                    ContactAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, comment: "联系地址"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessEnterprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessEnterprise_BusinessEnterpriseCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BusinessEnterpriseCategory",
                        principalColumn: "Id");
                },
                comment: "业务企业");

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "物品名称"),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "物品类别标识"),
                    BrandModel = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "品牌型号"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goods_GoodsCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "GoodsCategory",
                        principalColumn: "Id");
                },
                comment: "物品");

            migrationBuilder.CreateTable(
                name: "ContractItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "合同标识"),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "物品标识"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "数量"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "总价"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractItem_Contract_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contract",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContractItem_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "合同清单");

            migrationBuilder.CreateTable(
                name: "PurchaseRequestItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    PurchaseRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "采购需求标识"),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "物品标识"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "数量"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "总价"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseRequestItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItem_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseRequestItem_PurchaseRequest_PurchaseRequestId",
                        column: x => x.PurchaseRequestId,
                        principalTable: "PurchaseRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "采购需求清单");

            migrationBuilder.CreateTable(
                name: "ReturnGoodsItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    ReturnGoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "退货标识"),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "物品标识"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "数量"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "总价"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnGoodsItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnGoodsItem_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReturnGoodsItem_ReturnGoods_ReturnGoodsId",
                        column: x => x.ReturnGoodsId,
                        principalTable: "ReturnGoods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "退货清单");

            migrationBuilder.CreateTable(
                name: "StockItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "标识"),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "库存标识"),
                    GoodsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "物品标识"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "数量"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "单价"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "总价"),
                    Remark = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "备注"),
                    CreateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "创建时间"),
                    LastModifyTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, comment: "最后更新时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockItem_Goods_GoodsId",
                        column: x => x.GoodsId,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockItem_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "库存清单");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessEnterprise_CategoryId",
                table: "BusinessEnterprise",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItem_ContractId",
                table: "ContractItem",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractItem_GoodsId",
                table: "ContractItem",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_CategoryId",
                table: "Goods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItem_GoodsId",
                table: "PurchaseRequestItem",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseRequestItem_PurchaseRequestId",
                table: "PurchaseRequestItem",
                column: "PurchaseRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnGoodsItem_GoodsId",
                table: "ReturnGoodsItem",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnGoodsItem_ReturnGoodsId",
                table: "ReturnGoodsItem",
                column: "ReturnGoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_GoodsId",
                table: "StockItem",
                column: "GoodsId");

            migrationBuilder.CreateIndex(
                name: "IX_StockItem_StockId",
                table: "StockItem",
                column: "StockId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessEnterprise");

            migrationBuilder.DropTable(
                name: "ContractItem");

            migrationBuilder.DropTable(
                name: "PurchaseRequestItem");

            migrationBuilder.DropTable(
                name: "ReturnGoodsItem");

            migrationBuilder.DropTable(
                name: "StockItem");

            migrationBuilder.DropTable(
                name: "BusinessEnterpriseCategory");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "PurchaseRequest");

            migrationBuilder.DropTable(
                name: "ReturnGoods");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "GoodsCategory");
        }
    }
}
