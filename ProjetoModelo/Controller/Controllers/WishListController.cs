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
        [HttpPut]
        [Route("add")]
        public object addProductToWishList([FromBody] ProductDTO productDTO, [FromBody] WishListDTO wishlistDTO)
        {
            var product = model.Product.convertDTOToModel(productDTO);
            var wishlist = model.WishList.convertDTOToModel(wishlistDTO);

            wishlist.addProductToWishList(product);

            int id = wishlist.save();
            
            return new 
            {
                id = id,
                Client = wishlist.getClient().getLogin(),
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