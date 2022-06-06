using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("wishlist")]
    public class WishListController
    {
        [HttpPost]
        [Route("add")]
        public object addProductToWishList([FromBody] WishListDTO wishlistDTO)
        {
            var wishlist = model.WishList.convertDTOToModel(wishlistDTO);
            
            int id = wishlist.save();
            
            return new 
            {
                id = id,
                client = wishlist.getClient().getLogin(),
                product = wishlist.getProducts()
            };
        }

        [HttpDelete]
        [Route("remove")]
        public object removeProductFromwishList([FromBody] WishListDTO wishListDTO)
        {
            var wishlist = model.WishList.convertDTOToModel(wishListDTO);

            wishlist.delete();

            return new 
            {
                delete = "ok",
                problems = "no"
            };
        }

        [HttpGet]
        [Route("getproducts/{ClientId}")]
        public List<object> GetProducts(int ClientId)
        {
            return WishList.GetAllProducts(ClientId);
        }  
    }
}