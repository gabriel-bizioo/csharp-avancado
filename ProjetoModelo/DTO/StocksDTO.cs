using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StocksDTO
    {
        public int quantity;
        public double unit_price;

        public StoreDTO store;
        public ProductDTO product;
    }
}
