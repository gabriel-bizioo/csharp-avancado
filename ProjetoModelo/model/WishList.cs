using Interfaces;
using DAO;
using DTO;

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

        public WishList convertDTOToModel(WishListDTO obj)
        {

            WishList wishlist = new WishList(Client.convertDTOToModel(obj.client));



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

        //public int save()
        //{
        //    var id = 0;

        //    using (var context = new DaoContext())
        //    {
        //        var save_address = new DAO.Address
        //        {
        //            street = this.address.getStreet(),
        //            city = this.address.getCity(),
        //            state = this.address.getState(),
        //            country = this.address.getCountry(),
        //            postal_code = this.address.getPostalCode()
        //        };

        //        var owner = new DAO.Owner
        //        {
        //            name = this.name,
        //            email = this.email,
        //            phone = this.phone,
        //            login = this.login,
        //            passwd = this.passwd,
        //            date_of_birth = this.date_of_birth,
        //            address = save_address
        //        };

        //        context.Owner.Add(owner);

        //        id = owner.ID;

        //    }
        //    return id;
        //}

        public void update(WishListDTO wishlist)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(WishListDTO wishlist)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
