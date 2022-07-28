using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO
{
    public class RegisterProductDTO : ProductDTO
    {
        public int quantity;
        public double unit_price;

        public StoreDTO? store;
    }
}