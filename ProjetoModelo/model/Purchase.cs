using Enums;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

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

       
        public Boolean validateObject()
        {
            if (confirmation_number == null) {return false;}
            if (number_nf == null) {return false;}
            //if(purchase_value == null) {return false;}

            return true;
        }

        public PurchaseDTO convertModelToDTO()
        {
            PurchaseDTO purchaseDTO = new PurchaseDTO();
            purchaseDTO.purchase_date = this.purchase_date;
            purchaseDTO.payment_type = (int)this.payment_type;
            purchaseDTO.purchase_value = this.purchase_value;
            purchaseDTO.purchase_status = (int)this.purchase_status;
            purchaseDTO.number_confirmation = this.confirmation_number;
            purchaseDTO.number_nf = this.number_nf;

            foreach (var product in this.products)
            {
                purchaseDTO.products.Add(product.convertModelToDTO());
            }

            return purchaseDTO;
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase();

            if (obj.client != null)
            {
                purchase.client = Client.convertDTOToModel(obj.client);
            }

            if(obj.store != null)
            {
                purchase.store = Store.convertDTOToModel(obj.store);
            }

            purchase.confirmation_number = obj.number_confirmation;
            purchase.number_nf = obj.number_nf;
            purchase.payment_type = (PaymentEnum)obj.payment_type;
            purchase.purchase_status = (PurchaseStatusEnum)obj.purchase_status;
            purchase.purchase_date = obj.purchase_date;
            purchase.purchase_value = obj.purchase_value;

            foreach(var product in obj.products)
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
                if (this.products.Count() <= 0) { return -1; }

                var purchase = new DAO.Purchase
                {
                    purchase_date = this.purchase_date,
                    number_confirmation = this.confirmation_number,
                    number_nf = this.number_nf,
                    Payment = (int) this.payment_type,
                    PurchaseStatus = (int)this.purchase_status,
                    client = context.Client.FirstOrDefault(c => c.document == this.client.getDocument()),
                    store = context.Store.FirstOrDefault(s => s.cnpj == this.store.getCNPJ()),
                    product = context.Product.Where(p => p.bar_code == this.products.First().getBarCode()).Single()
                };

                context.Purchase.Add(purchase);
                context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
                this.products.Remove(products.First());
                this.save();
                id = purchase.ID;
            }
            return id;
        }

        public static void update(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void updateStatus()
        {
            if (this.purchase_status == PurchaseStatusEnum.awaitingPayment)
            {
                this.purchase_status = PurchaseStatusEnum.confirmedPayment;
            }
            else
            {
                this.purchase_status = PurchaseStatusEnum.awaitingPayment;
            }
        }

        public static List<object> getStorePurchases(int storeID)
        {
            using(var context = new DaoContext())
            {
                var storePurchase = context.Purchase
                    .Include(s => s.store)
                    .Include(o => o.store.owner)
                    .Include(a => a.store.owner.address)
                    .Include(p => p.product)
                    .Include(c => c.client)
                    .Include(a => a.client.address)
                    .Where(p => p.store.ID == storeID);
                List<object> purchases = new List<object>();
                foreach(var compra in storePurchase)
                {
                    purchases.Add(compra);
                }
                return purchases;

            }
        }

        public static List<object> getClientPurchases(int clientID)
        {
            using (var context = new DaoContext())
            {
                var clientPurchase = context.Purchase
                    .Include(s => s.store)
                    .Include(o => o.store.owner)
                    .Include(a => a.store.owner.address)
                    .Include(p => p.product)
                    .Include(c => c.client)
                    .Include(a => a.client.address)
                    .Where(p => p.client.ID == clientID);
                List<object> purchases = new List<object>();
                foreach (var compra in clientPurchase)
                {
                    purchases.Add(compra);
                }
                return purchases;

            }
        }

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
    }
}
