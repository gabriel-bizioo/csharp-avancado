using Interfaces;
using DAO;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        Product product = new Product();
        Client client;

        public WishList(Client client)
        {
            this.client = client;
        }

        public WishList()
        {

        }

        public Client getClient()
        {
            return client;
        }

        public Boolean validateObject()
        {
            if(product == null) return false;

            if(!client.validateObject()) return false;

            return true;
        }

        public WishListDTO convertModelToDTO()
        {
            WishListDTO obj = new WishListDTO();
            obj.client = this.client.convertModelToDTO();

            obj.wishlist_products.Add(product.convertModelToDTO());

            return obj;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {

            WishList wishlist = new WishList();

            wishlist.client = Client.convertDTOToModel(obj.client);

            foreach(var product in obj.wishlist_products)
            {
                wishlist.product = (model.Product.convertDTOToModel(product));
            }

            return wishlist;
        }

        public static IEnumerable<object> GetAllProducts(string clientinfo)
        {
            using(var context = new DaoContext())
            {
                var wishlists = context.WishList.Include(x => x.product)
                    .Where(wishlists => wishlists.client.email == clientinfo)
                    .Select(w => w.product)
                    .ToList();

                return wishlists;              
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
            return id;
        }

        public static bool Create(string clientinfo, string productinfo)
        {
            using(var context = new DaoContext())
            {
                var AddClient = context.Client.Where(cl => cl.email == clientinfo).FirstOrDefault();
                var AddProduct = context.Product.Where(pd => pd.bar_code == productinfo).FirstOrDefault();

                var repeats = context.WishList.Where(wl => wl.client.ID == AddClient.ID && wl.product.ID == AddProduct.ID).FirstOrDefault();

                Console.WriteLine(repeats);

                if(repeats == null)
                {
                    DAO.WishList wishList = new DAO.WishList()
                    {
                        product = AddProduct,
                        client = AddClient
                    };

                    context.Add(wishList);
                    context.SaveChanges();
                    
                    return true;
                }
                else
                {
                    return false;
                }                
            }
        }

        public void Update(WishListDTO wishlist)
        {
            throw new NotImplementedException();
        }

       public static void Delete(string clientinfo, string productinfo)
       {
            using(var context = new DaoContext())
            {
                try
                {
                    var wishlist = context.WishList.Where(wl => wl.product.bar_code == productinfo && wl.client.email == clientinfo).Single();

                    context.Remove(wishlist);
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
