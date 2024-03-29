﻿using Interfaces;
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
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
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
            var client = context.Client.FirstOrDefault(c => c.address.ID == address.ID);
            var owner = context.Owner.FirstOrDefault(o => o.address.ID == address.ID);
            if(client != null)
            {
                context.Remove(client.address);

            }
            else if(owner != null)
            {
                context.Remove(owner.address);
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
            var address = new DAO.Address
            {
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                postal_code = this.postal_code
            };

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
                if(addressDTO.street != null){
                    address.street = addressDTO.street;
                }
                if(addressDTO.city != null){
                    address.city = addressDTO.city;
                }
                if(addressDTO.state != null){
                    address.state = addressDTO.state;
                }
                if(addressDTO.country != null){
                    address.country = addressDTO.country;
                }
                if(addressDTO.postal_code != null){
                    address.postal_code = addressDTO.postal_code;
                }
            }
            context.SaveChanges();
        }
    }

    public AddressDTO findById(int id)
    {
        
        return new AddressDTO();
    }

    public static object find(int id)
    {
        using(var context = new DaoContext())
        {
            var address = context.Address.FirstOrDefault(a => a.ID == id);
            return new
            {
                street = address.street,
                state = address.state,
                city = address.city,
                country = address.country,
                postal_code = address.postal_code

            };
        }
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

        addressDTO.postal_code = this.postal_code;

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