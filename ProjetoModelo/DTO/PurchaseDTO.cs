using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class PurchaseDTO
    {
        DateTime purchase_date;
        double purchase_value;
        int payment_type;
        int purchase_status;
        string number_confirmation;
        string number_nf;

        List<ProductDTO> purchase_products;
    }
}
