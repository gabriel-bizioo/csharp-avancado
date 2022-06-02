using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PurchaseDTO
    {
        public PurchaseDTO(DateTime purchase_date,  double purchase_value, int payment_type, int purchase_status,
         string confirmation_number, string number_nf, StoreDTO store, ClientDTO client)
        {
            this.PurchaseDate = purchase_date;
            this.PurchaseValue = purchase_value;
            this.PaymentType = payment_type;
            this.PurchaseStatus = purchase_status;
            this.ConfirmationNumber = confirmation_number;
            this.NumberNF = number_nf;
            this.Store = store;
            this.Client = client;
        }
        
        public DateTime PurchaseDate;
        public double PurchaseValue;
        public int PaymentType;
        public int PurchaseStatus;
        public string ConfirmationNumber;
        public string NumberNF;

        public List<ProductDTO> PurchaseProducts = new List<ProductDTO>();
        public StoreDTO Store;
        public ClientDTO Client;
    }
}
