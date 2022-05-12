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
        var wishListModel = model.WishList.convertDTOToModel(wishList);
        var idClient = model.WishList.findId(wishList.client.document);
        var id = 0;
        foreach (var product in wishList.products)
        {
            var idProduto = model.Product.find(product);
            id = wishListModel.save(idClient, idProduto);
        }
        return new
        {
            id = id,
            client = wishList.client.document,
            produto = wishList.products
        };
    }

    [HttpDelete]
    [Route ("delete")]
    public object removeProductToWishList([FromBody] WishListDTO whishListDTO)
    {
        var whishList = model.WishList.convertDTOToModel(whishListDTO);

        whishList.delete(whishListDTO);

        return new
        {
            status = "ok",
            mensagem = "excluído"
        };
    }
}