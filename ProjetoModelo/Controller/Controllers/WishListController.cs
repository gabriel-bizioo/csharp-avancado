using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("wishList")]

public class WishListController : ControllerBase
{
    [HttpPost]
    [Route ("register")]
    public object addProductToWishList([FromBody] WishListDTO wishList)
    {
       
        var wishListModel = new model.WishList();
        var idClient = model.WishList.findId(wishList.client.document);
        var id = 0;
        foreach (var product in wishList.products)
        {
            var idProduto = model.Product.find(product);
            id = wishListModel.save(idClient, idProduto);
        }
        return new
        {
            id =0,
            client = wishList.client.document,
            produto = wishList.products
        };
    }

    [HttpDelete]
    [Route ("delete/{id}")]
    public void removeProductToWishList(int whishListDTO)
    {
        model.WishList.delete(whishListDTO);
    }
}