using Enums;
using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
    {
        public Purchase(DateTime purchase_date, string confirmation_number,string number_nf, PaymentEnum payment_type,
         PurchaseStatusEnum purchase_status, double purchase_value, Store store, Client client)
        {
            this.PurchaseDate = purchase_date;
            this.ConfirmationNumber = confirmation_number;
            this.NumberNF = number_nf;
            this.PaymentType = payment_type;
            this.PurchaseStatus = purchase_status;
            this.PurchaseValue = purchase_value;
            this.Store = store;
            this.Client = client;
        }
        
        DateTime PurchaseDate;
        string ConfirmationNumber;
        string NumberNF;
        PaymentEnum PaymentType;
        PurchaseStatusEnum PurchaseStatus;
        public double PurchaseValue;

        Store Store;

        Client Client;

        List<Product> Products = new List<Product>();

        public void setDataPurchase(DateTime date)
        {
            this.PurchaseDate = date;
        }

        public void setNumberConfirmation(string number)
        {
            this.ConfirmationNumber = number;
        }

        public void setNumberNf(string number_nf)
        {
            this.NumberNF = number_nf;
        }

        public void setPaymentType(PaymentEnum type)
        {
            this.PaymentType = type;
        }

        public void setPurchaseStatus(PurchaseStatusEnum status)
        {
            this.PurchaseStatus = status;
        }

        public void setProducts(List<Product> products)
        {
            this.Products = products;
        }

        public DateTime getPurchaseDate()
        {
            return PurchaseDate;
        }

        public int getPaymentType()
        {
            return (int)PaymentType;
        }

        public string getNumberConfirmation()
        {
            return ConfirmationNumber;
        }

        public string getNumberNf()
        {
            return NumberNF;
        }

        public Client getClient()
        {
            return Client;
        }

        public Store getStore()
        {
            return Store;
        }

        public List<Product> getProducts()
        {
            return Products;
        }

        public int getPurchaseStatus()
        {
            return (int)PurchaseStatus;
        }

        public Boolean validateObject()
        {
            if (ConfirmationNumber == null)
            {
                return false;
            }
            if(NumberNF == null)
            {
                return false;
            }
            return true;
        }

        public PurchaseDTO convertModelToDTO()
        {
            PurchaseDTO obj = new PurchaseDTO();
            obj.purchase_date = this.PurchaseDate;
            obj.payment_type = (int)this.PaymentType;
            obj.purchase_value = this.PurchaseValue;
            obj.purchase_status = (int)this.PurchaseStatus;
            obj.confirmation_number = this.ConfirmationNumber;
            obj.number_nf = this.NumberNF;
            obj.client = this.Client.convertModelToDTO();
            obj.store = this.Store.convertModelToDTO();
            
            foreach(var product in this.Products)
            {
                obj.purchase_products.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase(obj.purchase_date, obj.confirmation_number, obj.number_nf, (PaymentEnum)obj.payment_type, (PurchaseStatusEnum)obj.purchase_status,
                obj.purchase_value, model.Store.convertDTOToModel(obj.store), model.Client.convertDTOToModel(obj.client));

            if(obj.purchase_products != null)
            {
                foreach(var product in obj.purchase_products)
                {

                    purchase.Products.Add(Product.convertDTOToModel(product));
                }
            }
            

            return purchase;
        }

        public static DAO.Purchase findById(int id)
        {
            using(var context = new DaoContext())
            {
                var purchase = context.Purchase
                    .Include(p => p.product)
                    .Include( p => p.store)
                    .Include(p => p.client)
                    .FirstOrDefault(p => p.ID == id);

                return purchase;
            }
        }

        public static List<PurchaseDTO> getAll(int id, bool client)
        {
            List<PurchaseDTO> list = new List<PurchaseDTO>();            

            return list;
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var Store = context.Store.FirstOrDefault(s => s.cnpj == this.Store.getCNPJ());

                var Client = context.Client.FirstOrDefault(c => c.login == this.Client.getLogin());

                var Product = context.Product.FirstOrDefault(p => p.bar_code == this.Products.First().getBarCode());
                
                if(Store != null && Client != null && Product != null)
                {
                    var purchase = new DAO.Purchase
                    {
                        purchase_date = this.PurchaseDate,
                        confirmation_number = this.ConfirmationNumber,
                        purchase_value = this.PurchaseValue,
                        number_nf = this.NumberNF,
                        PurchaseStatus = (int)this.PurchaseStatus,
                        Payment = (int)this.PaymentType,
                    
                        store = Store,
                        client = Client,
                        product = Product
                    };
                    context.Purchase.Add(purchase);

                    context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                    context.SaveChanges();

                    id = purchase.ID;
                }                                
            }
            return id;
        }

        public void update(int purchaseID, PurchaseDTO purchaseDTO)
        {
            using(var context = new DaoContext())
            {
                var purchase = context.Purchase.FirstOrDefault(p => p.ID == purchaseID);

                if(purchase != null)
                {
                    if(purchaseDTO.purchase_date != null)
                    {
                        purchase.purchase_date = purchaseDTO.purchase_date;
                    }
                    if(purchaseDTO.confirmation_number != null)
                    {
                        purchase.confirmation_number = purchaseDTO.confirmation_number;
                    }
                    if(purchaseDTO.number_nf != null)
                    {
                        purchase.number_nf = purchaseDTO.number_nf;
                    }
                    
                    purchase.Payment = purchaseDTO.payment_type;
 
                    purchase.PurchaseStatus = purchaseDTO.purchase_status;
                    
                    purchase.purchase_value = purchaseDTO.purchase_value;
                }
                
                context.SaveChanges();
            }
        }

        public void delete(int purchaseID)
        {
            using(var context = new DaoContext())
            {
                var ToRemove = context.Purchase.Where(p => p.ID == purchaseID);
                foreach(var remove in ToRemove)
                {
                        context.Remove(remove);
                }
            }
        }

        public void updateStatus()
        {
            if(this.PurchaseStatus == PurchaseStatusEnum.awaitingPayment)
            {
                this.PurchaseStatus = PurchaseStatusEnum.confirmedPayment;
            }
            else
            {
                this.PurchaseStatus = PurchaseStatusEnum.awaitingPayment;
            }
        }

        public static List<object> getClientPurchases(int clientID)
        {
            using(var context = new DaoContext())
            {
                var get_purchases = context.Purchase
                    .Include(p => p.product)
                    .Include(p => p.store)
                    .Where(p => p.client.ID == clientID);

                List<object> purchases = new List<object>();

                foreach(var purchase in get_purchases)
                {
                    purchases.Add(purchase);
                }

                return purchases;
                
            }
        }

        public static List<object> getStorePurchases(int storeID)
        {
            using(var context = new DaoContext())
            {
                var get_purchases = context.Purchase
                    .Include(p => p.product)
                    .Include(p => p.store)
                    .Where(p => p.store.ID == storeID);

                List<object> purchases = new List<object>();

                foreach(var purchase in get_purchases)
                {
                    purchases.Add(purchase);
                }

                return purchases;
            }
        }

        public static void Create(Purchase purchase, string storeinfo, string productinfo, string clientinfo)
        {
            using(var context = new DaoContext())
            {
                try
                {
                    var Query = context.Store
                        .Join(context.Stocks, str => str.ID, stc => stc.store.ID, (str, stc) => new
                        {
                            StoreId = str.ID,
                            StoreCNPJ = str.cnpj,
                            ProductId = stc.product.ID,
                            ProductBarCode = stc.product.bar_code,
                            ProductQuantity = stc.quantity,
                            StocksId = stc.ID
                        })
                        .Join(context.Product, stc => stc.ProductId, pd => pd.ID, (stc, pd) => new
                        {
                            StoreId = stc.StoreId,
                            StoreCNPJ = stc.StoreCNPJ,
                            ProductId = stc.ProductId,
                            ProductBarCode = stc.ProductBarCode
                        })
                        .Where(c => c.ProductBarCode == productinfo && c.StoreCNPJ == storeinfo)
                        .Single();

                    var Product = context.Product
                        .Where(w => w.ID == Query.ProductId)
                        .Single();

                    var Store = context.Store
                        .Where(w => w.ID == Query.StoreId)
                        .Single();

                    var Client = context.Client
                        .Where(w => w.email == clientinfo)
                        .Single();

                    DAO.Purchase NewPurchase = new DAO.Purchase
                    {
                        client = Client,
                        product = Product,
                        store = Store,
                        number_nf = purchase.NumberNF,
                        confirmation_number = purchase.ConfirmationNumber,
                        purchase_date = DateTime.Now,
                        Payment = (int)purchase.PaymentType,
                        PurchaseStatus = (int)purchase.PurchaseStatus,
                        purchase_value = purchase.PurchaseValue
                    };

                    context.Add(NewPurchase);
                    context.SaveChanges();
                }
                catch(Exception error)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }
}
