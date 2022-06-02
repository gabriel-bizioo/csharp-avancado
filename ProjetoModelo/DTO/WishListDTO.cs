using System;

namespace DTO
{
    public class WishListDTO
    {
        public ClientDTO? client;
        public List<ProductDTO> wishlist_products = new List<ProductDTO>();
    }
}
