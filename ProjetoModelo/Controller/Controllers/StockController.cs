using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController
    {
        [HttpPost]
        [Route("add")]
        public object addProductToStock([FromBody] StocksDTO stocksDTO)
        {
            var stock = model.Stocks.convertDTOToModel(stocksDTO);

            int id = stock.save();

            return new
            {
                id = id,
                product = stock.GetProduct().getBarCode(),
                quantity = stock.GetQuantity(),
                unit_price = stock.getUnitPrice(),
                Store = stock.GetStore().getCNPJ()
            };
        }   

        [HttpPut]
        [Route("update/{stockID}")]
        public string updateStock(int stockID, [FromBody] StocksDTO stocksDTO)
        {
            model.Stocks.update(stockID, stocksDTO);

            return "stock updated";

        }     
    }
}