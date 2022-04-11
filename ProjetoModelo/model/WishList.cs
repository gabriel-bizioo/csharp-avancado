using Interfaces;

namespace model
{
    public class WishList : Person, IValidateDataObject<WishList>
    {
        List<Product> products = new List<Product>();
        Client client;

        public WishList(Address endereco, Client client) : base(endereco)
        {
            this.client = client;
        }
        
        public void addProductToWishList(Product product)
        {

            products.Add(product);

        }

        public Client getClient()
        {
            return client;
        }
        
        public List<Product> getProducts()
        {
            return products;
        }

        public Boolean validateObject(WishList wishlist)
        {
            if(wishlist.products == null) return false;

            if(!wishlist.client.validateObject(client)) return false;

            return true;
        }
    }
}
