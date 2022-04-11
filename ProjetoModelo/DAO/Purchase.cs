using Enums;
using Interfaces;

namespace DAO
{
    public class Purchase
    {
        public int ID;
        public DateTime purchase_date;
        public string number_confirmation;
        public string number_nf;
        public PaymentEnum Payment;
        public PurchaseStatusEnum PurchaseStatus;

        public Client client;

        public Product products;

        public Store store;

    }
}
