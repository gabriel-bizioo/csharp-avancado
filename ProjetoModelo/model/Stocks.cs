using Interfaces;
using DAO;
using DTO;

namespace model
{
    public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
    {
        int quantity;
        double unit_price;
        Store store;
        Product product;
        public List<StocksDTO> stocksDTO = new List<StocksDTO>();

        public Stocks() { }

        public Stocks(Store store, Product product)
        {
            this.product = product;
            this.store = store;
        }

        public static Stocks convertDTOToModel(StocksDTO obj)
        {
            Stocks stocks = new Stocks(Store.convertDTOToModel(obj.store), Product.convertDTOToModel(obj.product));

            stocks.quantity = obj.quantity;

            stocks.unit_price = obj.unit_price;

            return stocks;
        }
        public Boolean validateObject()
        {
            if (quantity == null) {return false;}
            if (unit_price == null) {return false;}
            return true;
        }

        public void delete(StocksDTO obj)
        {

        }

        public int save(int storeID, int productID, int quantidade, double unit_price)
        {
            var id = 0;

            using (var context = new DaoContext())
            {

                var store = context.Store.FirstOrDefault(p => p.ID == storeID); 
                var product = context.Product.FirstOrDefault(p => p.ID == productID);
                
                var stocks = new DAO.Stocks
                {
                    quantity = this.quantity,
                    unit_price = this.unit_price,
                    store = store,
                    product = product,
                };

                context.Stocks.Add(stocks);

                context.SaveChanges();

                id = stocks.ID;

            }
            return id;
        }

        public void update(StocksDTO obj)
        {

        }

        public StocksDTO findById(int id)
        {

            return new StocksDTO();
        }

        public List<StocksDTO> getAll()
        {
            return this.stocksDTO;
        }


        public StocksDTO convertModelToDTO()
        {
            var stocksDTO = new StocksDTO();

            stocksDTO.store = this.store.convertModelToDTO();
            stocksDTO.product = this.product.convertModelToDTO();
            stocksDTO.quantity = this.quantity;
            stocksDTO.unit_price = this.unit_price;

            return stocksDTO;
        }

        public void setStore(Store store)
        {
            this.store = store;
        }

        public void setProduct(Product product)
        {
            this.product = product;
        }

        public void setUnitPrice(double unit_price)
        {
            this.unit_price = unit_price;
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

        public double getUnitprice()
        {
            return unit_price;
        }

        public int GetQuantity()
        {
            return quantity;
        }

    }
}
