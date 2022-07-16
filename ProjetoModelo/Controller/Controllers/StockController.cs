using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public IActionResult addProductToStock([FromBody] StocksDTO stocksDTO)
        {
            var stock = model.Stocks.convertDTOToModel(stocksDTO);

            int id = stock.save();

            var NewProductToStock = new
            {
                id = id,
                product = stock.GetProduct().getBarCode(),
                quantity = stock.GetQuantity(),
                unit_price = stock.getUnitPrice(),
                Store = stock.GetStore().getCNPJ()
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            var result = new ObjectResult(NewProductToStock);

            return result;
        }   

        [HttpPut]
        [Route("update/{stockID}")]
        public IActionResult updateStock(int stockID, [FromBody] StocksDTO stocksDTO)
        {
            model.Stocks.update(stockID, stocksDTO);

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var status = new
            {
                status = "Update ok"
            };

            var result = new ObjectResult(status);

            return result;
        }   

        [HttpGet]
        [Route("get")]
        public IActionResult GetAll()
        {
            var AllStocks = model.Stocks.GetAll();

            var result = new ObjectResult(AllStocks);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;

        }  
    }
}