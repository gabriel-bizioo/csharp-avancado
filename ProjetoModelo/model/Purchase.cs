using Enums;
using Interfaces;

namespace model
{
    public class Purchase : IValidateDataObject<Purchase>
    {
        DateTime purchase_date;
        string number_confirmation;
        string number_nf;
        PaymentEnum Payment;
        PurchaseStatusEnum PurchaseStatus;

        Client client;

        List<Product> products;

        public void setDataPurchase(DateTime date)
        {
            this.purchase_date = date;
        }

        public void setNumberConfirmation(string number)
        {
            this.number_confirmation = number;
        }

        public void setNumberNf(string number_nf)
        {
            this.number_nf = number_nf;
        }

        public void setPaymentType(PaymentEnum type)
        {
            this.Payment = type;
        }

        public void setPurchaseStatus(PurchaseStatusEnum status)
        {
            this.PurchaseStatus = status;
        }

        public void setProducts(List<Product> products)
        {
            this.products = products;
        }

        public DateTime getPurchaseDate()
        {
            return purchase_date;
        }

        public int getPaymentType()
        {
            return (int)Payment;
        }

        public string getNumberConfirmation()
        {
            return number_confirmation;
        }

        public string getNumberNf()
        {
            return number_nf;
        }

        public Client getClient()
        {
            return client;
        }

        public List<Product> getProducts()
        {
            return products;
        }

        public int getPurchaseStatus()
        {
            return (int)PurchaseStatus;
        }

        public Boolean validateObject(Purchase purchase)
        {
            if (purchase.number_confirmation == null)
            {
                return false;
            }
            if(purchase.number_nf == null)
            {
                return false;
            }
            return true;
        }
    }
}
