using Interfaces;

namespace model
{
    public class Store : IValidateDataObject<Store>
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

        public Boolean validateObject(Store store)
        {
            if (store.name == null) return false;

            if(store.cnpj == null) return false;

            if(!store.owner.validateObject(owner)) return false;

            if(store.purchases == null) return false;

            return true;
        }

    }
}
