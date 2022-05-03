using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
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
    private String post_code;
    public List<AddressDTO> addressDTO = new List<AddressDTO>();

    public Address(string street, string city, string state, string country, string post_code)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.post_code = post_code;
        }

    public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.poste_code);
    }

    public Boolean validateObject()
    {
        if (street == null) { return false; }
        if (city == null) { return false; }
        if (state == null) { return false; }
        if (country == null) { return false; }
        if (post_code == null) { return false; }
        return true;
    }

    public void delete(AddressDTO obj)
    {
        using (var context = new DaoContext())
        {
            var address = context.Address.FirstOrDefault(/*x => x.id == this.id*/);
            context.Address.Remove(address);
            context.SaveChanges();

        }
    }

    public int save()
    {
        var id = 0;

        using (var context = new DaoContext())
        {
            var address = new DAO.Address
            {
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                postal_code = this.post_code
            };

            context.Address.Add(address);

            context.SaveChanges();

            id = address.ID;

        }
        return id;
    }

    public void update(AddressDTO obj)
    {

    }

    public AddressDTO findById(int id)
    {

        return new AddressDTO();
    }

    public List<AddressDTO> getAll()
    {
        return this.addressDTO;
    }


    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO();

        addressDTO.street = this.street;

        addressDTO.state = this.state;

        addressDTO.city = this.city;

        addressDTO.country = this.country;

        addressDTO.poste_code = this.post_code;

        return addressDTO;
    }


    public void setStreet(string street)
    {
        this.street = street;
    }

    public void setCity(string city)
    {
        this.city = city;
    }

     public void setState(string state)
     {
         this.state = state;
     }

     public void setCountry(string country)
     {
         this.country = country;
     }

     public void setPostCode(string post_code)
     {
         this.post_code = post_code;
     }

     public string getStreet()
     {
         return street;
     }

     public string getCity()
     {
         return city;
     }

     public string getState()
     {    
         return state;   
     } 

     public string getCountry()
     {
         return country;
     }

     public string getPostalCode()
     {
         return post_code;
     }  
        

}