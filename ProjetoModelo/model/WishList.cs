using Interfaces;
using DAO;
using DTO;
using System.Linq;

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

        public WishListDTO findById(int id)
        {
            WishListDTO wishlist = null;

            return wishlist;
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
                var product = context.Product.FirstOrDefault(p => p.bar_code == this.products.First().getBarCode());
                
                var wishlist = new DAO.WishList
                {
                    client = client,
                    product = product

                };

                context.WishList.Add(wishlist);

                context.Entry(wishlist.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wishlist.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                context.SaveChanges();

                id = wishlist.ID;

            }
            return id;
        }

        public void update(WishListDTO wishlist)
        {
            Console.WriteLine("Not yet implemented");
        }

        public static void delete(int wishlistID)
        {
            using(var context = new DaoContext())
            {
                context.Remove(context.WishList.FirstOrDefault(w => w.ID == wishlistID));

                context.SaveChanges();
            }
        }
    }
}
