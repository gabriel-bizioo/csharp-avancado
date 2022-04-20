using Interfaces;
using DAO;
using DTO;
namespace model
{
    public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
    {
        int quantity;
        
        Store store;
        Product product;

        public Stocks(Store store, Product product)
        {
            this.product = product;
            this.store = store;
        }

        public Stocks()
        {

        }

        public void setStore(Store store)
        {
            this.store = store;
        }

        public void setProduct(Product product)
        {
            this.product = product;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }

        public Store GetStore()
        {
            return store;
        }

        public Product GetProduct()
        {
            return product;
        }

        public int GetQuantity()
        {
            return quantity;
        }


        public Boolean validateObject()
        {
            if (quantity <= 0) return false;

            if (!store.validateObject()) return false;

            if (!store.validateObject()) return false;

            return true;
        }

        public StocksDTO convertModelToDTO()
        {
            StocksDTO obj = new StocksDTO();
            obj.quantity = this.quantity;
            obj.store = this.store.convertModelToDTO();
            obj.product = this.product.convertModelToDTO();

            return obj;
        }

        public Stocks onvertDTOToModel(StocksDTO obj)//implementar
        {
            Stocks purchase = new Stocks(Store.convertDTOToModel(obj.store), Product.convertDTOToModel(obj.product));

            purchase.quantity = this.quantity;         

            return purchase;
        }

        public StocksDTO findById(int id)
        {
            StocksDTO purchase = null;

            return purchase;
        }

        public List<StocksDTO> getAll()
        {
            List<StocksDTO> list = new List<StocksDTO>();

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

        public void update(StocksDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(StocksDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
    
}
