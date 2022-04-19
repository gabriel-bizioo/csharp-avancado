using Enums;
using Interfaces;
using DAO;
using DTO;

namespace model
{
    public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
    {
        DateTime purchase_date;
        string number_confirmation;
        string number_nf;
        double purchase_value;
        PaymentEnum payment_type;
        PurchaseStatusEnum purchase_status;

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
            return (int)purchase_status;
        }

        public Boolean validateObject()
        {
            if (number_confirmation == null)
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
            obj.number_confirmation = this.number_confirmation;
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

            purchase.number_confirmation = obj.number_confirmation;
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

        //public int save()
        //{
        //    var id = 0;

        //    using (var context = new DaoContext())
        //    {

        //        var product = new DAO.Product
        //        {
        //            name = this.name,
        //            bar_code = this.bar_code
        //        };


        //        context.Product.Add(product);

        //        id = product.ID;

        //    }
        //    return id;
        //}

        public void update(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(PurchaseDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
