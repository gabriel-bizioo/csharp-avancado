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
    [Route("delete")]
    public object deleteProduct(ProductDTO product)
    {
        var productModel = model.Product.convertDTOToModel(product);
        productModel.delete(product);
        return new
        {
            status = "ok",
            mensagem = "Excluido com sucesso"
        };
    }

    [HttpPut]
    [Route("put")]
    public void updateProduct(ProductDTO product) { }
}