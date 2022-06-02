using System;
using Interfaces;
using DAO;
using DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace model
{
    public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
    {
        Guid uuid;


        private Owner(string name, DateTime date_of_birth, string document, string email,
         string login, string passwd) : base(name, date_of_birth, document, email, login, passwd)
        {  }
        
        
        public static Owner getInstance(Address endereco)
        {
            throw new NotImplementedException();
        }

        public Boolean validateObject()
        {
            if(Document == null) return false;
            if(Name == null) return false;
            if(Email == null) return false;
            if(Phone == null) return false;
            if(Login == null) return false;
            if(Passwd == null) return false;

            return true;
        }

        public int getID()
        {
            using(var context = new DaoContext())
            {
                var owner = context.Owner.FirstOrDefault(i => i.Login == this.Login);
                if (owner != null)
                {
                    return owner.ID;
                }
                else
                {
                    return 0;
                }
                
            }
        }

        public OwnerDTO convertModelToDTO()
        {
            OwnerDTO obj = new OwnerDTO(this.Name, this.DateOfBirth, this.Document, this.Email, this.Login, this.Passwd);
            if(this.Address != null)
            {
                obj.Address = Address.convertModelToDTO();
            }       

            obj.Phone = this.Phone;

            return obj;
        }

        public static Owner convertDTOToModel(OwnerDTO obj)
        {
            Owner owner = new Owner(obj.Name, obj.DateOfBirth, obj.Document, obj.Email, obj.Login, obj.Passwd);
            if(obj.Address != null) { owner.Address = Address.convertDTOToModel(obj.Address); }

            return owner;
        }

        public OwnerDTO findById(int id)
        {
            throw new NotImplementedException();
        }

        public static object find(int id)
        {
            using (var context = new DaoContext())
            {
                var owner = context.Owner.Include(i => i.Address).FirstOrDefault(c => c.ID == id);
                return new
                {
                    name = owner.Name,
                    email = owner.Email,
                    phone = owner.Phone,
                    login = owner.Login,
                    passwd = owner.Passwd,
                    document = owner.Document,
                    date_of_birth = owner.DateOfBirth,
                    address = owner.Address
                };
            }
        }

        public List<OwnerDTO> getAll()
        {
            List<OwnerDTO> list = new List<OwnerDTO>();

            return list;
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {
                if(this.Address != null)
                {
                    var save_address = new DAO.Address(this.Address.getStreet(), this.Address.getCity(), 
                    this.Address.getState(), this.Address.getCountry(), this.Address.getPostalCode());

                    var Owner = new DAO.Owner(this.Name, this.DateOfBirth, this.Document, this.Email, this.Login, this.Passwd)
                    {
                        Address = save_address
                    };
                    context.Owner.Add(Owner);
                    context.SaveChanges();
                    id = Owner.ID;
                }
                else
                {
                    var Owner = new DAO.Owner(this.Name, this.DateOfBirth, this.Email, this.Document, this.Login, this.Passwd)
                    {
                        Phone = this.Phone
                    };
                    context.Owner.Add(Owner);
                    context.SaveChanges();
                    id = Owner.ID;
                }          
            }
            return id;
        }

        public void update(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }

        public void delete(OwnerDTO owner)
        {
            throw new NotImplementedException();
        }
    }
}
