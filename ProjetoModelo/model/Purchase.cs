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
            PurchaseDTO obj = new PurchaseDTO(this.PurchaseDate, this.PurchaseValue , (int)this.PaymentType,
             (int)this.PurchaseStatus, this.ConfirmationNumber, this.NumberNF, this.Store.convertModelToDTO(), this.Client.convertModelToDTO());
            
            foreach(var product in this.Products)
            {
                obj.PurchaseProducts.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static Purchase convertDTOToModel(PurchaseDTO obj)
        {
            Purchase purchase = new Purchase(obj.PurchaseDate, obj.ConfirmationNumber, obj.NumberNF, (PaymentEnum)obj.PaymentType, (PurchaseStatusEnum)obj.PurchaseStatus,
                obj.PurchaseValue, model.Store.convertDTOToModel(obj.Store), model.Client.convertDTOToModel(obj.Client));

            if(obj.PurchaseProducts != null)
            {
                foreach(var product in obj.PurchaseProducts)
                {

                    purchase.Products.Add(Product.convertDTOToModel(product));
                }
            }
            

            return purchase;
        }

        public PurchaseDTO findById(int id)
        {
            throw new NotImplementedException();
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

                var Client = context.Client.FirstOrDefault(c => c.Login == this.Client.getLogin());

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
                    if(purchaseDTO.PurchaseDate != null)
                    {
                        purchase.purchase_date = purchaseDTO.PurchaseDate;
                    }
                    if(purchaseDTO.ConfirmationNumber != null)
                    {
                        purchase.confirmation_number = purchaseDTO.ConfirmationNumber;
                    }
                    if(purchaseDTO.NumberNF != null)
                    {
                        purchase.number_nf = purchaseDTO.NumberNF;
                    }
                    
                    purchase.Payment = purchaseDTO.PaymentType;
 
                    purchase.PurchaseStatus = purchaseDTO.PurchaseStatus;
                    
                    purchase.purchase_value = purchaseDTO.PurchaseValue;
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
    }
}
