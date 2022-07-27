using Interfaces;
using DAO;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        Stocks Stock = new Stocks();
        Client Client;

        public WishList(Client client)
        {
            this.Client = client;
        }

        public WishList()
        {

        }

        public Client getClient()
        {
            return Client;
        }

        public Boolean validateObject()
        {
            if(Stock == null) return false;

            if(!Client.validateObject()) return false;

            return true;
        }

        public WishListDTO convertModelToDTO()
        {
            WishListDTO obj = new WishListDTO();
            obj.Client = this.Client.convertModelToDTO();

            obj.Stock = Stock.convertModelToDTO();

            return obj;
        }

        public static WishList convertDTOToModel(WishListDTO obj)
        {

            WishList wishlist = new WishList();

            wishlist.Client = Client.convertDTOToModel(obj.Client);


            wishlist.Stock = model.Stocks.convertDTOToModel(obj.Stock);

            return wishlist;
        }

        public static IEnumerable<object> GetAllProducts(string clientinfo)
        {
            // .Join(context.Stocks, ws => ws.Stocks.ID, sc => sc.ID, (ws, sc) => new
            // {

            //     price = sc.unit_price,
            //     StoreId = sc.store.ID,
            //     ProductId = sc.product.
            // })
            // .Join(context.Product, sc => sc.ProductId, pd => pd.ID, (sc, pd) => new
            // {
            //     id = pd.ID,
            //     storeId = sc.StoreId
            //     price = sc.price,
            // })

            //.Where(wishlists => wishlists.client.email == clientinfo)

            using(var context = new DaoContext())
            {
                var wishlists = context.WishList
                    .Where(wishlists => wishlists.Client.email == clientinfo)
                    .Select(w => new
                    {
                        id = w.Stock.product.ID,
                        storeId = w.Stock.store.ID,
                        name = w.Stock.product.name,
                        price = w.Stock.unit_price,
                        imgLink = w.Stock.product.img_link,
                        barCode = w.Stock.product.bar_code
                    })
                    .ToList();

                return wishlists;      
            }
        }

        public List<WishListDTO> getAll()
        {
            List<WishListDTO> list = new List<WishListDTO>();

            return list;
        }


        public static bool Save(string clientinfo, string productinfo, int storeinfo)
        {
            using(var context = new DaoContext())
            {
                var AddClient = context.Client
                    .Where(cl => cl.email == clientinfo)
                    .FirstOrDefault();

                var AddStock = context.Stocks
                    .Where(sc => sc.product.bar_code == productinfo && sc.store.ID == storeinfo)
                    .FirstOrDefault();

                var repeats = context.WishList
                    .Where(wl => wl.Client.ID == AddClient.ID && wl.Stock.ID == AddStock.ID)
                    .FirstOrDefault();

                if(repeats == null)
                {
                    DAO.WishList wishList = new DAO.WishList()
                    {
                        Stock = AddStock,
                        Client = AddClient
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
                    var wishlist = context.WishList
                        .Where(wl => wl.Stock.product.bar_code == productinfo && wl.Client.email == clientinfo)
                        .Single();

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
