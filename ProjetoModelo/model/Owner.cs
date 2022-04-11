using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace model
{
    public class Owner : Person
    {
        public static Owner owner;

        private Owner(Address endereco) : base(endereco)
        {

        }
        
        
        public static Owner getInstance(Address endereco)
        {
            if(owner == null)
            {
                owner = new Owner(endereco);
            }
            return owner;
        }

        public Boolean validateObject(Owner owner)
        {
            if (owner.name == null) return false;

            if (owner.document == null) return false;

            if (owner.email == null) return false;

            if (owner.phone == null) return false;

            if (owner.login == null) return false;

            if (!owner.endereco.validateObject(endereco)) return false;

            return true;
        }
    }
}
