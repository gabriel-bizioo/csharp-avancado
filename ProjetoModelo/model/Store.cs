using Interfaces;
using DAO;
using DTO;

namespace model
{
    public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
    {
        public Owner owner;
        string name;
        string cnpj;

        List<Purchase> purchases;

        public Store(string name, string cnpj, Owner owner)
        {
            this.owner = owner;
            this.name = name;
            this.cnpj = cnpj;
            purchases = new List<Purchase>();
        }

        public Store(string name, string cnpj, Owner owner, List<Purchase> purchases)
        {
            this.owner = owner;
            this.name = name;
            this.cnpj = cnpj;
            this.purchases = purchases;
        }
        
        public Store(Owner owner)
        {
            this.owner = owner;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setCNPJ(string cnpj)
        {
            this.cnpj=cnpj;
        }

        public string getName()
        {
            return name;
        }

        public string getCNPJ()
        {
            return cnpj;
        }

        public Owner getOwner()
        {
            return owner;
        }
        
        public void AddNewPurchase(Purchase purchase)
        {
            purchases.Add(purchase);
        }

        public Boolean validateObject()
        {
            if (name == null) return false;

            if(cnpj == null) return false;

            if(!owner.validateObject()) return false;

            if(purchases == null) return false;

            return true;
        }

        public StoreDTO convertModelToDTO()
        {
            StoreDTO obj = new StoreDTO();
            obj.name = this.name;
            obj.CNPJ = this.cnpj;
            obj.Owner = this.owner.convertModelToDTO();

            foreach(var product in purchases)
            {
                obj.purchases.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static Store convertDTOToModel(StoreDTO obj)
        {

            Store store = new Store(Owner.convertDTOToModel(obj.Owner));

            store.name = obj.name;
            store.cnpj = obj.CNPJ;

            return store;
        }

        public StoreDTO findById(int id)
        {
            StoreDTO store = null;

            return store;
        }

        public List<StoreDTO> getAll()
        {
            List<StoreDTO> list = new List<StoreDTO>();

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

        public void update(StoreDTO store)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(StoreDTO store)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
