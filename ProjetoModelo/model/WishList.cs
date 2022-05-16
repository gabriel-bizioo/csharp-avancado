using Interfaces;
using DAO;
using DTO;

namespace model
{
    public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
    {
        List<Product> products;
        Client client;
        public List<WishListDTO> wishListDTO = new List<WishListDTO>();

        public WishList() { }

        public WishList(Client client)
        {
            this.client = client;
        }


        public static WishList convertDTOToModel(WishListDTO obj)
        {
            var wishList = new WishList(Client.convertDTOToModel(obj.client));

            foreach (var prod in obj.products)
            {
                wishList.addProductToWishList(Product.convertDTOToModel(prod));
            }

            return wishList;
        }

        public Boolean validateObject()
        {
            if (products == null) {return false;}
            return true;
        }

        public static void delete(int wishList)
        {
            using (var context = new DaoContext())
            {
                context.WishList.Remove(context.WishList.FirstOrDefault(a => a.ID == wishList));
                context.SaveChanges();

            }
        }

        public int save(int clientID, int productID)
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var client = context.Client.FirstOrDefault(c => c.ID == clientID);
                var product = context.Product.FirstOrDefault(p => p.ID == productID);

                var wishlist = new DAO.WishList();
                {
                    wishlist.client = client;
                    wishlist.product = product;
                };

                context.WishList.Add(wishlist);

                id = wishlist.ID;
                context.Entry(wishlist.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wishlist.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.SaveChanges();
            }
            return id;
        }

        public static int GetClientID(Client client)
        {
            int id;
            using (var context = new DaoContext())
            {
                var clientDAO = context.Client.FirstOrDefault(i => i.document == client.getDocument());
                id = clientDAO.ID;
            }
            return id;
        }

        public void update(WishListDTO obj)
        {

        }

        public WishListDTO findById(int id)
        {

            return new WishListDTO();
        }

        public List<WishListDTO> getAll()
        {
            return this.wishListDTO;
        }


        public WishListDTO convertModelToDTO()
        {
            WishListDTO wishListDTO = new WishListDTO();
            wishListDTO.client = this.client.convertModelToDTO();

            foreach (var product in products)
            {
                wishListDTO.products.Add(product.convertModelToDTO());
            }

            return wishListDTO;
        }

        public static int findId(string document)
        {
            using (var context = new DaoContext())
            {
                var client = context.Client.FirstOrDefault(s => s.document == document);
                return client.ID;
            }
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

        public void SetClient(Client client)
        {
            this.client = client;
        }

        public void SetProducts(List<Product> products)
        {
            this.products = products;
        }
    }
}
