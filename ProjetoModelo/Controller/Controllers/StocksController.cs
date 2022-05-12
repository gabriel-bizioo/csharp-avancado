using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("stocks")]

public class StocksController : ControllerBase
{

    [HttpPost]
    [Route("register")]
    public object addProductToStock([FromBody] StocksDTO stocks)
    {

        var stockModel = model.Stocks.convertDTOToModel(stocks);
        var productId = model.Product.findId(stockModel.GetProduct().getBarCode());
        var storeId = model.Store.findId(stockModel.GetStore().getCNPJ());
        var id = stockModel.save(storeId, productId, stockModel.GetQuantity(), stockModel.getUnitprice());

        return new
        {
            id = id,
            quantity = stocks.quantity,
            unit_price = stocks.unit_price,
            product = stocks.product,
            store = stocks.store
        };
    }

    [HttpPut]
    [Route("update")]
    public void updateStock(Object request) { }
}