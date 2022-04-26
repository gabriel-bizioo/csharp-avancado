using Enums;
using Interfaces;
using DAO;
using DTO;
using System.Linq;

namespace model
{
    public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
    {
        DateTime purchase_date;
        string confirmation_number;
        string number_nf;
        PaymentEnum payment_type;
        PurchaseStatusEnum purchase_status;
        public double purchase_value;

        Store store;

        Client client;

        List<Product> products = new List<Product>();

        public void setDataPurchase(DateTime date)
        {
            this.purchase_date = date;
        }

        public void setNumberConfirmation(string number)
        {
            this.confirmation_number = number;
        }

        public void setNumberNf(string number_nf)
        {
            this.number_nf = number_nf;
        }

        public void setPaymentType(PaymentEnum type)
        {
            this.payment_type = type;
        }

        public void setPurchaseStatus(PurchaseStatusEnum status)
        {
            this.purchase_status = status;
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
            return (int)payment_type;
        }

        public string getNumberConfirmation()
        {
            return confirmation_number;
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
            return (int)purchase_status;
        }

        public Boolean validateObject()
        {
            if (confirmation_number == null)
            {
                return false;
            }
            if(number_nf == null)
            {
                return false;
            }
            return true;
        }

        public PurchaseDTO convertModelToDTO()
        {
            PurchaseDTO obj = new PurchaseDTO();
            obj.purchase_date = this.purchase_date;
            obj.payment_type = (int)this.payment_type;
            obj.purchase_value = this.purchase_value;
            obj.purchase_status = (int)this.purchase_status;
            obj.confirmation_number = this.confirmation_number;
            obj.number_nf = this.number_nf;
            
            foreach(var product in this.products)
            {
                obj.purchase_products.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase();

            purchase.confirmation_number = obj.confirmation_number;
            purchase.number_nf = obj.number_nf;
            purchase.payment_type = (PaymentEnum)obj.payment_type;
            purchase.purchase_status = (PurchaseStatusEnum)obj.purchase_status;

            foreach(var product in obj.purchase_products)
            {

                purchase.products.Add(Product.convertDTOToModel(product));
            }

            return purchase;
        }

        public PurchaseDTO findById(int id)
        {
            PurchaseDTO purchase = null;

            return purchase;
        }

        public List<PurchaseDTO> getAll()
        {
            List<PurchaseDTO> list = new List<PurchaseDTO>();

            return list;
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var store = context.Store.FirstOrDefault(s => s.ID == 1);

                var client = context.Client.FirstOrDefault(c => c.ID == 1);

                var product = context.Product.Where(p => p.ID == 1).Single();
                
                var purchase = new DAO.Purchase
                {
                    purchase_date = this.purchase_date,
                    confirmation_number = this.confirmation_number,
                    purchase_value = this.purchase_value,
                    number_nf = this.number_nf,
                    PurchaseStatus = (int)this.purchase_status,
                    Payment = (int)this.payment_type,
                    store = store,
                    client = client,
                    product = product
                };


                context.Purchase.Add(purchase);

                context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                context.SaveChanges();

                id = purchase.ID;

            }
            return id;
        }

        public void update(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void updateStatus()
        {
            if(this.purchase_status == PurchaseStatusEnum.awaitingPayment)
            {
                this.purchase_status = PurchaseStatusEnum.confirmedPayment;
            }
            else
            {
                this.purchase_status = PurchaseStatusEnum.awaitingPayment;
            }
        }
    }
}
