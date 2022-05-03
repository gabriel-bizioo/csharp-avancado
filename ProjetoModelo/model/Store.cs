using Interfaces;
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace model
{
    public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
    {     
        string name;
        string cnpj;
        Owner owner;
        List<Purchase> purchases = new List<Purchase>();


        public List<StoreDTO> storeDTO = new List<StoreDTO>();

        public static Store convertDTOToModel(StoreDTO obj)
        {
            Store store = new Store();

            if (obj.owner != null)
            {
                store.owner = Owner.convertDTOToModel(obj.owner);

            }

            store.name = obj.name;

            store.cnpj = obj.cnpj;

            foreach (var purchase in obj.purchases)
            {
                if (purchase != null) { store.purchases.Add(Purchase.convertDTOToModel(purchase)); }
            }

            return store;
        }

        public Boolean validateObject()
        {
            if (name == null) { return false; }
            if (cnpj == null) { return false; }
            return true;
        }

        public void delete(StoreDTO obj)
        {
            Console.WriteLine("Not yet implemented");
        }

        public int save(int ownerID)
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                var owner = context.Owner.Where(c => c.ID == ownerID).Single();

                var store = new DAO.Store
                {
                    name = this.name,
                    cnpj = this.cnpj,    
                    owner = owner,
                };

                context.Store.Add(store);

                context.SaveChanges();

                id = store.ID;

            }
            return id;
        }

        public void update(StoreDTO obj)
        {
            Console.WriteLine("Not yet implemented");
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


        public StoreDTO convertModelToDTO()
        {
            var storeDTO = new StoreDTO();

            storeDTO.name = this.name;
            storeDTO.name = this.name;
            storeDTO.owner = this.owner.convertModelToDTO();

            return storeDTO;
        }

        public static object getStoreInformation(int storeId)
        {
            using(var context = new DaoContext())
            {
                var storeDAO = context.Store.Include(s => s.owner).Where(p => p.ID == storeId);

                return storeDAO;
            }
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
    }
}
