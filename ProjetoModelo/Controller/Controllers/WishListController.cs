using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
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
                product = wishlist.getProducts().First().getBarCode()
            };
        }

        [HttpDelete]
        [Route("remove")]
        public void removeProductFromwishList()
        {
            
        }
        
    }
}