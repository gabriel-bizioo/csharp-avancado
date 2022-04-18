using Interfaces;

namespace model
{
    public class Stocks : IValidateDataObject<Stocks>
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

        

        public Boolean validateObject(Stocks stock)
        {
            if (stock.quantity <= 0) return false;

            if (unit_price <= 0) return false;

            if (!stock.store.validateObject(store)) return false;

            if(!stock.product.validateObject(product)) return false;

            return true;
        }
    }
}
