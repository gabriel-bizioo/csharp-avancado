using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;


namespace model
{
    public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
    {
        int quantity;
        double unit_price;
        
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

        public double getUnitPrice()
        {
            return unit_price;
        }


        public Boolean validateObject()
        {
            if (quantity <= 0) return false;

            if (!store.validateObject()) return false;

            if (!product.validateObject()) return false;


            return true;
        }

        public StocksDTO convertModelToDTO()
        {
            StocksDTO obj = new StocksDTO();
            obj.unit_price = this.unit_price;
            obj.quantity = this.quantity;
            obj.store = this.store.convertModelToDTO();
            obj.product = this.product.convertModelToDTO();

            return obj;
        }

        public static Stocks convertDTOToModel(StocksDTO obj)
        {
            Stocks purchase = new Stocks(Store.convertDTOToModel(obj.store), Product.convertDTOToModel(obj.product));

            purchase.quantity = obj.quantity;         

            return purchase;
        }

        public StocksDTO findById(int id)
        {
            throw new NotImplementedException();
        }
// .Join(context.Product, stocks => stocks.product.ID, pd => pd.ID, (stocks, pd) => new 
//                     {
//                         id = stocks.ID,
//                         storeId = stocks.store.ID,
//                         name = pd.name,
//                         price = stocks.unit_price,
//                         imgLink = pd.img_link,
//                         barCode = pd.bar_code
//     })
        public static IEnumerable<object> GetAll()
        {
            using(var context = new DaoContext())
            {
                var AllStocks = context.Stocks
                    .Select(x => new
                    {
                        id = x.ID,
                        storeId = x.store.ID,
                        name = x.product.name,
                        price = x.unit_price,
                        imgLink = x.product.img_link,
                        barCode = x.product.bar_code
                    })
                    .ToList();

                return AllStocks;
            }            
        }

        public int save()
        {
            var id = 0;
            
            using (var context = new DaoContext())
            {
                var store = context.Store.FirstOrDefault(s => s.cnpj == this.store.getCNPJ());

                var product = context.Product.FirstOrDefault(p => p.bar_code == this.product.getBarCode());

                if(store != null && product != null)
                {
                    var stocks = new DAO.Stocks
                    {
                        quantity = this.quantity,

                        unit_price = this.unit_price,

                        store = store,

                        product = product
                    };


                    context.Stocks.Add(stocks);

                    context.Entry(stocks.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    context.Entry(stocks.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                    context.SaveChanges();

                    id = stocks.ID;
                }
            }
            return id;
        }

        public static void update(int stockID, StocksDTO stocksDTO)
        {
            using(var context = new DaoContext())
            {
                var stock = context.Stocks.FirstOrDefault(s => s.ID == stockID);

                if(stock != null)
                {
                    if(stocksDTO.quantity >= 0)
                    {
                        stock.quantity = stocksDTO.quantity;
                    }
                    if(stocksDTO.unit_price >= 0)
                    {
                        stock.unit_price = stocksDTO.unit_price;
                    }

                    context.SaveChanges();
                }
            }
        }

        public void delete(StocksDTO purchase)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
    
}
