using System;

namespace DTO
{
    public class WishListDTO
    {
        public ClientDTO? Client;
        public StocksDTO Stock = new StocksDTO();
    }
}
