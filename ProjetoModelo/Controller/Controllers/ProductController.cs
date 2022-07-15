using System;
using DTO;
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

        [HttpPost]
        [Route("register")]
        public IActionResult registerProducts([FromBody]ProductDTO productDTO)
        {
            var product = model.Product.convertDTOToModel(productDTO);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            int id = product.save();

            var obg = new
            {
                name = productDTO.name,
                bar_code = productDTO.bar_code,
                img_link = productDTO.img_link,
                ID = id
            };

            var result = new ObjectResult(obg);

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

            var GetProduct = new
            {
                name = Product.name,
                bar_code = Product.bar_code,
                img_link = Product.img_link,
                ID = id
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(GetProduct);

            return result;
        }
    }
}