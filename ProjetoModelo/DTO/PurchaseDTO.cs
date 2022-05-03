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
        public string number_confirmation;
        public string number_nf;
        public List<ProductDTO> products = new List<ProductDTO>();
     
        public ClientDTO client;
        public StoreDTO store;
    }
}
