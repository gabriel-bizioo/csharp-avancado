using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;


namespace Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController
    {
        [HttpGet]
        [Route("getAll")]
        public List<object> allProducts()
        {
            var products = model.Product.getAllProducts();

            return products;
        }

        [HttpPost]
        [Route("register")]
        public object registerProducts([FromBody]ProductDTO productDTO)
        {
            var product = model.Product.convertDTOToModel(productDTO);

            int id = product.save();

            return new
            {
                name = productDTO.name,
                bar_code = productDTO.bar_code,
                ID = id
            };
        }

        public void deleteProduct(ProductDTO product)
        {
            
        }


        public void updateProduct(ProductDTO product)
        {

        }
        
    }
}