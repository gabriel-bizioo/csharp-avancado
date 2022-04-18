using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class StocksDTO
    {
        public int quantity;
        double unit_price;

        public StoreDTO store;
        public ProductDTO product;
    }
}
