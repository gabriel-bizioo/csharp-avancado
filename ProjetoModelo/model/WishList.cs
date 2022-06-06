using Interfaces;
using DAO;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        List<Product> products = new List<Product>();
        Client client;

        public WishList(Client client)
        {
            this.client = client;
        }

        public WishList()
        {

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

        public Boolean validateObject()
        {
            if(products == null) return false;

            if(!client.validateObject()) return false;

            return true;
        }

        public WishListDTO convertModelToDTO()
        {
            WishListDTO obj = new WishListDTO();
            obj.client = this.client.convertModelToDTO();

            foreach (var product in products)
            {
                obj.wishlist_products.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {

            WishList wishlist = new WishList();

            wishlist.client = Client.convertDTOToModel(obj.client);

            foreach(var product in obj.wishlist_products)
            {
                wishlist.products.Add(model.Product.convertDTOToModel(product));
            }

            return wishlist;
        }

        public static List<object> GetAllProducts(int ClientId)
        {
            List<object> products = new List<object>();
            using(var context = new DaoContext())
            {
                var wishlists = context.WishList.Include(x => x.product).Where(wishlists => wishlists.client.ID == ClientId);
                foreach(var wishlist in wishlists)
                {
                    if(wishlist.product != null)
                        products.Add(wishlist.product);
                }
                return products;              
            }
        }

        public List<WishListDTO> getAll()
        {
            List<WishListDTO> list = new List<WishListDTO>();

            return list;
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var client = context.Client.FirstOrDefault(c => c.login == this.client.getLogin());
                
                
                foreach(var product in this.products)
                {
                    var currentProduct = context.Product.FirstOrDefault(p => p.bar_code == product.getBarCode());

                    var wishlist = new DAO.WishList
                    {
                        client = client,
                        product = currentProduct

                    };

                    context.WishList.Add(wishlist);

                    context.Entry(wishlist.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                    context.Entry(wishlist.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                    context.SaveChanges();

                    id = wishlist.ID;
                }                   

            }
            return id;
        }

        public void update(WishListDTO wishlist)
        {
            throw new NotImplementedException();
        }

        public async void delete()
        {
            using(var context = new DaoContext())
            {
                var wishlist = context.WishList.Where(w => w.client.login == this.client.getLogin());
                foreach(var product in this.products)
                {
                    context.Remove(wishlist.FirstOrDefault(w => w.product.bar_code == product.getBarCode()));
                }

                context.SaveChanges();
            }
        }
    }
}
