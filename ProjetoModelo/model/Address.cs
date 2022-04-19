﻿using System;
using Interfaces;
using DAO;
using DTO;
using System.Collections.Generic;

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

    public void delete(AddressDTO obj)
    {

    }

    //public int save()
    //{
    //    var id = 0;

    //    using (var context = new DaoContext())
    //    {
    //        var address = new DAO.Address
    //        {
    //            street = this.street,
    //            city = this.city,
    //            state = this.state,
    //            country = this.country,
    //            postal_code = this.postal_code
    //        };

    //        context.Address.Add(address);

    //        context.SaveChanges();

    //        id = address.ID;

    //    }
    //    return id;
    //}

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