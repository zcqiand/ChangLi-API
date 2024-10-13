using ChangLi.Shared.DTO.BusinessEnterprise;
using ChangLi.Shared.Models;
using ChangLi.Shared.DTO.BusinessEnterprise;
using ChangLi.Shared.DTO.BusinessEnterpriseCategory;
using ChangLi.Shared.DTO.Contract;
using ChangLi.Shared.DTO.ContractItem;
using ChangLi.Shared.DTO.Goods;
using ChangLi.Shared.DTO.GoodsCategory;
using ChangLi.Shared.DTO.PurchaseRequest;
using ChangLi.Shared.DTO.PurchaseRequestItem;
using ChangLi.Shared.DTO.ReturnGoods;
using ChangLi.Shared.DTO.ReturnGoodsItem;
using ChangLi.Shared.DTO.Stock;
using ChangLi.Shared.DTO.StockItem;

namespace ChangLi.API.Mappers;

/// <summary>
/// 
/// </summary>
public class DtoToDomainProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public DtoToDomainProfile()
    {
        #region BusinessEnterprise
        CreateMap<BusinessEnterpriseCreateInDto, BusinessEnterprise>();
        CreateMap<BusinessEnterpriseUpdateInDto, BusinessEnterprise>();
        CreateMap<BusinessEnterprise, BusinessEnterpriseQueryOutDto>();
        CreateMap<BusinessEnterprise, BusinessEnterpriseGetOutDto>();
        #endregion

        #region BusinessEnterpriseCategory
        CreateMap<BusinessEnterpriseCategoryCreateInDto, BusinessEnterpriseCategory>();
        CreateMap<BusinessEnterpriseCategoryUpdateInDto, BusinessEnterpriseCategory>();
        CreateMap<BusinessEnterpriseCategory, BusinessEnterpriseCategoryQueryOutDto>();
        CreateMap<BusinessEnterpriseCategory, BusinessEnterpriseCategoryGetOutDto>();
        #endregion

        #region Contract
        CreateMap<ContractCreateInDto, Contract>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<ContractUpdateInDto, Contract>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<Contract, ContractQueryOutDto>();
        CreateMap<Contract, ContractGetOutDto>();
        #endregion

        #region ContractItem
        CreateMap<ContractItemCreateInDto, ContractItem>();
        CreateMap<ContractItemUpdateInDto, ContractItem>();
        CreateMap<ContractItem, ContractItemQueryOutDto>();
        CreateMap<ContractItem, ContractItemGetOutDto>();
        CreateMap<ContractItem, ContractItemModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Goods.Name))
            .ForMember(d => d.BrandModel, opt => opt.MapFrom(src => src.Goods.BrandModel));
        #endregion

        #region Goods
        CreateMap<GoodsCreateInDto, Goods>();
        CreateMap<GoodsUpdateInDto, Goods>();
        CreateMap<Goods, GoodsQueryOutDto>();
        CreateMap<Goods, GoodsGetOutDto>();
        #endregion

        #region GoodsCategory
        CreateMap<GoodsCategoryCreateInDto, GoodsCategory>();
        CreateMap<GoodsCategoryUpdateInDto, GoodsCategory>();
        CreateMap<GoodsCategory, GoodsCategoryQueryOutDto>();
        CreateMap<GoodsCategory, GoodsCategoryGetOutDto>();
        #endregion

        #region PurchaseRequest
        CreateMap<PurchaseRequestCreateInDto, PurchaseRequest>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<PurchaseRequestUpdateInDto, PurchaseRequest>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<PurchaseRequest, PurchaseRequestQueryOutDto>();
        CreateMap<PurchaseRequest, PurchaseRequestGetOutDto>();
        #endregion

        #region PurchaseRequestItem
        CreateMap<PurchaseRequestItemCreateInDto, PurchaseRequestItem>();
        CreateMap<PurchaseRequestItemUpdateInDto, PurchaseRequestItem>();
        CreateMap<PurchaseRequestItem, PurchaseRequestItemQueryOutDto>();
        CreateMap<PurchaseRequestItem, PurchaseRequestItemGetOutDto>();
        CreateMap<PurchaseRequestItem, PurchaseRequestItemModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Goods.Name))
            .ForMember(d => d.BrandModel, opt => opt.MapFrom(src => src.Goods.BrandModel));
        #endregion

        #region ReturnGoods
        CreateMap<ReturnGoodsCreateInDto, ReturnGoods>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<ReturnGoodsUpdateInDto, ReturnGoods>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<ReturnGoods, ReturnGoodsQueryOutDto>();
        CreateMap<ReturnGoods, ReturnGoodsGetOutDto>();
        #endregion

        #region ReturnGoodsItem
        CreateMap<ReturnGoodsItemCreateInDto, ReturnGoodsItem>();
        CreateMap<ReturnGoodsItemUpdateInDto, ReturnGoodsItem>();
        CreateMap<ReturnGoodsItem, ReturnGoodsItemQueryOutDto>();
        CreateMap<ReturnGoodsItem, ReturnGoodsItemGetOutDto>();
        CreateMap<ReturnGoodsItem, ReturnGoodsItemModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Goods.Name))
            .ForMember(d => d.BrandModel, opt => opt.MapFrom(src => src.Goods.BrandModel));
        #endregion

        #region Stock
        CreateMap<StockCreateInDto, Stock>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<StockUpdateInDto, Stock>()
            .ForMember(x => x.Items, opt => opt.Ignore());
        CreateMap<Stock, StockQueryOutDto>();
        CreateMap<Stock, StockGetOutDto>();
        #endregion

        #region StockItem
        CreateMap<StockItemCreateInDto, StockItem>();
        CreateMap<StockItemUpdateInDto, StockItem>();
        CreateMap<StockItem, StockItemQueryOutDto>();
        CreateMap<StockItem, StockItemGetOutDto>();
        CreateMap<StockItem, StockItemModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.Goods.Name))
            .ForMember(d => d.BrandModel, opt => opt.MapFrom(src => src.Goods.BrandModel));
        #endregion
    }
}