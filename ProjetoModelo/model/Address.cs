using Interfaces;
using DAO;
using DTO;

namespace model;

public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
{
    private String street;

    private String city;

    private String state;

    private String country;

    private String postal_code;

    public List<AddressDTO> addressDTO = new List<AddressDTO>();

    public Address(String street, String city, String state, String country, String postal_code)
    {
        this.street = street;

        this.city = city;

        this.state = state;

        this.country = country;

        this.postal_code = postal_code;
    }

    public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.Street, obj.City, obj.State, obj.Country, obj.PostalCode);
    }   
     public Boolean validateObject()
    {
        return true;
    }

    public static void delete(int id)
    {
        using(var context = new DaoContext())
        {
            var address = context.Address.FirstOrDefault(a => a.ID == id);
            var client = context.Client.FirstOrDefault(c => c.Address.ID == address.ID);
            var owner = context.Owner.FirstOrDefault(o => o.Address.ID == address.ID);
            if(client != null)
            {
                context.Remove(client.Address);
            }
            else if(owner != null)
            {
                context.Remove(owner.Address);
            }
            else
            {
                context.Remove(address);
            }

            context.SaveChanges();
        }
    }

    public int save()
    {
        int id = 0;

        using (var context = new DaoContext())
        {
            var address = new DAO.Address(this.street, this.city, this.state, this.country, this.postal_code);

            context.Address.Add(address);

            context.SaveChanges();

            id = address.ID;
        }
        return id;
    }

    public static void update(int id, AddressDTO addressDTO)
    {
        using(var context = new DaoContext())
        {
            var address = context.Address.FirstOrDefault(a => a.ID == id);

            if(address != null){
                if(addressDTO.Street != null){
                    address.Street = addressDTO.Street;
                }
                if(addressDTO.City != null){
                    address.City = addressDTO.City;
                }
                if(addressDTO.State != null){
                    address.State = addressDTO.State;
                }
                if(addressDTO.Country != null){
                    address.Country = addressDTO.Country;
                }
                if(addressDTO.PostalCode != null){
                    address.PostalCode = addressDTO.PostalCode;
                }
            }
            context.SaveChanges();
        }
    }

    public AddressDTO findById(int id)
    {
        
        throw new NotImplementedException();
    }

    public static object find(int id)
    {
        using(var context = new DaoContext())
        {
            var address = context.Address.FirstOrDefault(a => a.ID == id);
            return new
            {
                street = address.Street,
                state = address.State,
                city = address.City,
                country = address.Country,
                postal_code = address.PostalCode

            };
        }
    }

    public List<AddressDTO> getAll()
    {
        return this.addressDTO;
    }


    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO(this.street, this.city,
         this.state, this.country, this.postal_code);

        return addressDTO;
    }

    public void setStreet(String street)
    {
        this.street = street;
    }

    public void setCity(String city)
    {
        this.city = city;
    }

    public void setState(String state)
    {
        this.state = state;
    }

    public void setCountry(String country)
    {
        this.country = country;
    }

    public void setPostalCode(String postal_code)
    {
        this.postal_code = postal_code;
    }

    public String getStreet()
    {
        return this.street;
    }

    public String getCity()
    {
        return this.city;
    }

    public String getState()
    {
        return this.state;
    }

    public String getCountry()
    {
        return this.country;
    }

    public String getPostalCode()
    {
        return this.postal_code;
    }

}