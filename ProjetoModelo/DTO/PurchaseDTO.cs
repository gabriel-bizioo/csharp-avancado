using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseDTO
    {
        public DateTime purchase_date;
        public double purchase_value;
        public int payment_type;
        public int purchase_status;
        public string? confirmation_number;
        public string? number_nf;

        public List<ProductDTO> purchase_products = new List<ProductDTO>();
        public StoreDTO store = new StoreDTO();
        public ClientDTO client = new ClientDTO();
    }
}
