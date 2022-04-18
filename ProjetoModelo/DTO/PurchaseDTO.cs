using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseDTO
    {
        public DateTime data_purchase;
        public double purchase_value;
        public int payment_type;
        public int purchase_status;
        public string number_confirmation;
        public string number_nf;
    }
}
