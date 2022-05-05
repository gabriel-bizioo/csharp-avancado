using Interfaces;
using DAO;
using DTO;
using System.Linq;

namespace model
{
    public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
    {
        public Owner owner;
        string name;
        string cnpj;

        List<Purchase> purchases = new List<Purchase>();

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

        public Store()
        {

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

            Store store = new Store();

            if(obj.Owner != null)
            {
                store.owner = Owner.convertDTOToModel(obj.Owner);
            }

            store.name = obj.name;
            store.cnpj = obj.CNPJ;

            foreach (var purchase in obj.purchases)
            {
                store.AddNewPurchase(Purchase.convertDTOToModel(purchase));
            }

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

        public int save(int ownerID)
        {
            var id = 0;

            using (var context = new DaoContext())
            {

                var owner = context.Owner.Where(o => o.ID == ownerID).Single();

                var store = new DAO.Store
                {
                    owner = owner,
                    name = this.name,
                    cnpj = this.cnpj
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
            Console.WriteLine("Not yet implemented");
        }

        public void delete(StoreDTO store)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
