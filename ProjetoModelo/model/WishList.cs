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
            WishList wishlist = new WishList(Client.convertDTOToModel(obj.client));

            foreach (var product in obj.products)
            {
                wishlist.products.Add(Product.convertDTOToModel(product));
            }

            return wishlist;
        }

        public Boolean validateObject()
        {
            if (products == null) {return false;}
            return true;
        }

        public void delete(WishListDTO obj)
        {

        }

        public int save(int clientID, int productID)
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var client = context.Client.FirstOrDefault(c => c.ID == clientID);
                var product = context.Product.Where(p => p.ID == productID).Single();

                var wishlist = new DAO.WishList();
                {
                    wishlist.client = client;
                    wishlist.product = product;
                };

                context.WishList.Add(wishlist);

                context.SaveChanges();

                id = wishlist.ID;

                context.Entry(wishlist.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                context.Entry(wishlist.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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
    }
}
