using Interfaces;
using DAO;
using DTO;
using System.Linq;

namespace model
{
    public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
    {
        public Owner Owner;
        string Name;
        string Cnpj;

        List<Purchase> purchases = new List<Purchase>();

        public Store(string name, string cnpj, Owner owner)
        {
            this.Owner = owner;
            this.Name = name;
            this.Cnpj = cnpj;
            purchases = new List<Purchase>();
        }

        public Store(string name, string cnpj, Owner owner, List<Purchase> purchases)
        {
            this.Owner = owner;
            this.Name = name;
            this.Cnpj = cnpj;
            this.purchases = purchases;
        }

        public Store(){}
        
        public Store(Owner owner)
        {
            this.Owner = owner;
        }

        public void setName(string name)
        {
            this.Name = name;
        }

        public void setCNPJ(string cnpj)
        {
            this.Cnpj=cnpj;
        }

        public string getName()
        {
            return Name;
        }

        public string getCNPJ()
        {
            return Cnpj;
        }

        public Owner getOwner()
        {
            return Owner;
        }
        
        public void AddNewPurchase(Purchase purchase)
        {
            purchases.Add(purchase);
        }

        public Boolean validateObject()
        {
            if (Name == null) return false;

            if(Cnpj == null) return false;

            return true;
        }

        public StoreDTO convertModelToDTO()
        {
            StoreDTO obj = new StoreDTO();
            obj.name = this.Name;
            obj.CNPJ = this.Cnpj;
            obj.Owner = this.Owner.convertModelToDTO();

            foreach(var product in purchases)
            {
                obj.purchases.Add(product.convertModelToDTO());
            }

            return obj;
        }

        public static Store convertDTOToModel(StoreDTO obj)
        {

            Store store = new Store();

            if(obj.Owner != null)
            {
                store.Owner = Owner.convertDTOToModel(obj.Owner);
            }

            store.Name = obj.name;
            store.Cnpj = obj.CNPJ;

            foreach (var purchase in obj.purchases)
            {
                store.AddNewPurchase(Purchase.convertDTOToModel(purchase));
            }

            return store;
        }

        public StoreDTO findById(int id)
        {
            throw new NotImplementedException();
        }

        public static DAO.Store find(int id)
        {
            using(var context = new DaoContext())
            {
                var store = context.Store.FirstOrDefault(s => s.ID == id);

                return store;
            }
        }

        public List<StoreDTO> getAll()
        {
            List<StoreDTO> list = new List<StoreDTO>();

            return list;
        }

        
        public static List<object> getAllStores()
        {
            using(var context = new DaoContext())
            {
                var stores = context.Store;

                List<object> storelist = new List<object>();

                foreach(var store in stores)
                {
                    storelist.Add(store);
                }

                return storelist;
            }
        }

        public int Save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {

                var owner = context.Owner
                    .Where(o => o.email == this.Owner.getEmail())
                    .Single();

                var store = new DAO.Store
                {
                    owner = owner,
                    name = this.Name,
                    cnpj = this.Cnpj
                };

                context.Store.Add(store);

                context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

                context.SaveChanges();

                id = store.ID;
            }
            return id;
        }

        public void update(StoreDTO store)
        {
            throw new NotImplementedException();
        }

        public void delete(StoreDTO store)
        {
            throw new NotImplementedException();
        }
    }
}
