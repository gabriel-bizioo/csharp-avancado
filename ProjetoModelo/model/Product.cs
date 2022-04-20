using Interfaces;
using DTO;
using DAO;

namespace model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO, Product>
    {
        string name;
        string bar_code;
        double unit_price;

        public void setName(string name)
        {
            this.name = name;
        }

        public void setBarCode(string barcode)
        {
            this.bar_code = barcode;
        }

        public void setUnitPrice(double value)
        {
            if (value < 0)
            {
                unit_price = 0;
            }

            unit_price = value;
        }
        

        public string getName()
        {
            return name;
        }

        public string getBarCode()
        {
            return bar_code;
        }
        
        public double getUnitPrice()
        {
            return unit_price;
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
            List<ProductDTO> list = new List<ProductDTO>();

            return list;
        }

        //public int save()
        //{
        //    var id = 0;

        //    using (var context = new DaoContext())
        //    {

        //        var product = new DAO.Product
        //        {
        //            name = this.name,
        //            bar_code = this.bar_code
        //        };


        //        context.Product.Add(product);

        //        id = product.ID;

        //    }
        //    return id;
        //}

        public void update(ProductDTO client)
        {
            Console.WriteLine("Not yet implemented");
        }

        public void delete(ProductDTO client)
        {
            Console.WriteLine("Not yet implemented");
        }
    }
}
