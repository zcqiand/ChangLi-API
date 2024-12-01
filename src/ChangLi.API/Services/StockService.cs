using ChangLi.Infrastructure;
using ChangLi.Shared.DTO.Stock;

namespace ChangLi.HostApp.Services;

/// <summary>
/// 库存
/// </summary>
public class StockService : ServiceBase
{
    private readonly ChangLiDbContext _dbContext;
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="serviceProvider"></param>
    public StockService(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _dbContext = serviceProvider.GetRequiredService<ChangLiDbContext>();
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<Guid> Create(StockCreateInDto input)
    {
        var model = Mapper.Map<Stock>(input);
        
        model.Id = NewId.NextSequentialGuid();

        await CreateItems(input, model);

        await _dbContext.Stocks.AddAsync(model);

        await _dbContext.SaveChangesAsync();

        return model.Id;
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Update(StockUpdateInDto input)
    {
        var model = await _dbContext.Stocks.Include(x => x.Items).SingleAsync(x => x.Id.Equals(input.Id));

        Mapper.Map(input, model);

        await UpdateItems(input, model);

        model.LastModifyTime = DateTimeOffset.Now;

        await _dbContext.SaveChangesAsync();

        return true;
    }



    private async Task CreateItems(StockCreateInDto input, Stock model)
    {
        model.Items.Clear();

        foreach (var item in input.Items)
        {
            var goods = await _dbContext.Goods.FirstOrDefaultAsync(x => x.Name.Equals(item.Name) && x.BrandModel.Equals(item.BrandModel));
            if (goods == null)
            {
                goods = new Goods
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = item.Name,
                    BrandModel = item.BrandModel
                };

                await _dbContext.Goods.AddAsync(goods);
            }
            var stockItem = new StockItem
            {
                Id = NewId.NextSequentialGuid(),
                GoodsId = goods.Id,
                Goods = goods,
                StockId = model.Id,
                Stock = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(stockItem);
        }
    }

    private async Task UpdateItems(StockUpdateInDto input, Stock model)
    {
        model.Items.Clear();

        foreach (var item in input.Items)
        {
            var goods = await _dbContext.Goods.FirstOrDefaultAsync(x => x.Name.Equals(item.Name) && x.BrandModel.Equals(item.BrandModel));
            if (goods == null)
            {
                goods = new Goods
                {
                    Id = NewId.NextSequentialGuid(),
                    Name = item.Name,
                    BrandModel = item.BrandModel
                };

                await _dbContext.Goods.AddAsync(goods);
            }

            var stockItem = new StockItem
            {
                Id = NewId.NextSequentialGuid(),
                Goods = goods,
                GoodsId = goods.Id,
                StockId = model.Id,
                Stock = model,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice
            };

            model.Items.Add(stockItem);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> Delete(StockDeleteInDto input)
    {
        var model = await _dbContext.Stocks.SingleAsync(x => x.Id.Equals(input.Id));

        _dbContext.Stocks.Remove(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<bool> BatchDelete(StockBatchDeleteInDto input)
    {
        var model = await _dbContext.Stocks.Where(x => input.Ids.Contains(x.Id)).ToListAsync();

        _dbContext.Stocks.RemoveRange(model);

        await _dbContext.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// 获取清单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<PagingOutBase<StockQueryOutDto>> Query(StockQueryInDto input)
    {
        var query = from a in _dbContext.Stocks.AsNoTracking()
                    select a;

        #region filter
        #endregion

        var total = await query.CountAsync();

        var items = await query
            .OrderByDescending(x => x.LastModifyTime)
            .Skip((input.PageIndex - 1) * input.PageSize)
            .Take(input.PageSize)
            .ToListAsync();

        var itemDtos = Mapper.Map<IList<StockQueryOutDto>>(items);

        return new PagingOutBase<StockQueryOutDto>(total, itemDtos);
    }

    /// <summary>
    /// 获取详情
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public async Task<StockGetOutDto> Get(StockGetInDto input)
    {
        var query = from a in _dbContext.Stocks.Include(x => x.Items).ThenInclude(x => x.Goods).AsNoTracking()
                    where a.Id == input.Id
                    select a;

        var items = await query.SingleAsync();

        return Mapper.Map<StockGetOutDto>(items);
    }
}
