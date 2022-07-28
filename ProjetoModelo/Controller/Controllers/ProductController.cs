using System;
using DTO;
using Controller;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;


namespace Controller.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("getAll")]
        public IActionResult allProducts()
        {
            var products = model.Product.getAllProducts();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(products);

            return result;
        }

        [Authorize]
        [HttpPost]
        [Route("register")]
        public IActionResult registerProducts([FromBody]RegisterProductDTO registerproductDTO)
        {
            ProductDTO productDTO = new ProductDTO
            {
                name = registerproductDTO.name,
                img_link = registerproductDTO.img_link,
                bar_code = registerproductDTO.bar_code
            };
            Console.WriteLine(registerproductDTO.unit_price);
            StocksDTO stocksDTO = new StocksDTO
            {
                quantity = registerproductDTO.quantity,
                unit_price = (double)registerproductDTO.unit_price,
                store = registerproductDTO.store,
                product = productDTO
            };
            
            var product = model.Product.convertDTOToModel(productDTO);

            int id = product.save();

            var stock = model.Stocks.convertDTOToModel(stocksDTO);

            int StockId = stock.save();

            var obg = new
            {
                name = productDTO.name,
                bar_code = productDTO.bar_code,
                img_link = productDTO.img_link,
                ID = id
            };

            var result = new ObjectResult(obg);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;            
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{id}")]
        public IActionResult deleteProduct(int id)
        {
            model.Product.delete(id);
            
            var status = new
            {
                status = "Update ok"
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(status);

            return result;
        }

        [Authorize]
        [HttpPut]
        [Route("update/{id}")]
        public IActionResult updateProduct(int id, [FromBody]ProductDTO productDTO)
        {
            model.Product.update(id, productDTO);

            var status = new
            {
                status = "Update ok"
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(status);

            return result;
        }
        
        
        [HttpGet]
        [Route("get/{id}")]
        public IActionResult getProduct(int id)
        {
            var Product = model.Product.findById(id);

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(Product);

            return result;
        }
    }
}