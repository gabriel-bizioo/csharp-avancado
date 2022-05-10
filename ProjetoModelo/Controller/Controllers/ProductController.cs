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

        [HttpDelete]
        [Route("remove/{id}")]
        public void deleteProduct(int id)
        {
            model.Product.delete(id);
        }


        [HttpPut]
        [Route("update/{id}")]
        public void updateProduct(int id, [FromBody]ProductDTO productDTO)
        {
            model.Product.update(id, productDTO);
        }
        
    }
}