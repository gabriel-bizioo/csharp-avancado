namespace DAO
{
    public class Purchase
    {
        public int ID;
        public DateTime purchase_date;
        public string? confirmation_number;
        public string? number_nf;
        public int Payment;
        public int PurchaseStatus;
        public double purchase_value;

        public Client? client;

        public Product? product;

        public Store? store;
    }
}
