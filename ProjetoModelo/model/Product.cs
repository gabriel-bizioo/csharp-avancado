﻿using Interfaces;
using DTO;
using DAO;
using System.Linq;

namespace model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
    {
        string name;
        string bar_code;

        public void setName(string name)
        {
            this.name = name;
        }

        public void setBarCode(string barcode)
        {
            this.bar_code = barcode;
        }
        

        public string getName()
        {
            return name;
        }

        public string getBarCode()
        {
            return bar_code;
        }
  


        public Boolean validateObject()
        {
            if (name == null) return false;

            if (bar_code == null) return false;

            return true;
        }

        public ProductDTO convertModelToDTO()
        {
            ProductDTO obj = new ProductDTO();
            obj.name = this.name;
            obj.bar_code = this.bar_code;

            return obj;
        }

        public static Product convertDTOToModel(ProductDTO obj)
        {
            Product product = new Product();

            product.name = obj.name;
            product.bar_code = obj.bar_code;

            return product;
        }

        public ProductDTO findById(int id)
        {
            ProductDTO product = null;

            return product;
        }

        public List<ProductDTO> getAll()
        {

            return new List<ProductDTO>();
        }

        public static List<object> getAllProducts()
        {
            using (var context = new DaoContext())
            {
                var products = context.Product;

                List<object> productlist = new List<object>();

                foreach(var product in products)
                {
                    productlist.Add(product);
                }

                return productlist;
            }           
        }

        public int save()
        {
            var id = 0;

            using (var context = new DaoContext())
            {

                var product = new DAO.Product
                {
                    name = this.name,
                    bar_code = this.bar_code
                };


                context.Product.Add(product);

                context.SaveChanges();

                id = product.ID;

            }
            return id;
        }

        public static void update(int productID, ProductDTO productDTO)
        {
            using(var context = new DaoContext())
            {
                var product = context.Product.FirstOrDefault(p => p.ID == productID);

                if(product != null)
                {
                    if(productDTO.name != null)
                    {
                        product.name = productDTO.name;
                    }
                    if(productDTO.bar_code != null)
                    {
                        product.bar_code = productDTO.bar_code;
                    }
                }
                
                context.SaveChanges();
            }
        }

        public static void delete(int productID)
        {
            using(var context = new DaoContext())
            {

                context.Product.Remove(context.Product.FirstOrDefault(p => p.ID == productID));

                context.SaveChanges();
            }
        }
    }
}
