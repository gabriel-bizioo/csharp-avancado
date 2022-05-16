using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("product")]

public class ProductController : ControllerBase
{
    public void allProducts() { }

    [HttpPost]
    [Route("create")]
    public object createProduct([FromBody] ProductDTO product) 
    {
        var productModel = model.Product.convertDTOToModel(product);
        var id = productModel.save();
        return new
        {
            nome = product.name,
            bar_code = product.bar_code,
            id = id
        };
    }

    [HttpDelete]
    [Route("delete/{id}")]
    public void deleteProduct(int id)
    {
       model.Product.delete(id);
    }

    [HttpPut]
    [Route("put/{id}")]
    public void updateProduct(int id, ProductDTO product) 
    {
        model.Product.update(id,product);
    }
}