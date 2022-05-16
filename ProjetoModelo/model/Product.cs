using Interfaces;
using DAO;
using DTO; 

namespace model
{
    public class Product : IValidateDataObject, IDataController<ProductDTO,Product>
    {
        string name;
        string bar_code;
        public List<ProductDTO> productsDTO = new List<ProductDTO>();

        public Product() { }

        public Product(string name, string bar_code)
        {
            this.name = name;
            this.bar_code = bar_code;
        }

        public static Product convertDTOToModel(ProductDTO obj)
        {
            var product = new Product();
            product.name = obj.name;
            product.bar_code = obj.bar_code;
            return product;
        }

        public Boolean validateObject()
        {
            if (this.name == null) {return false;}
            if (this.bar_code == null) {return false;}
            return true;
        }

        public static void delete(int productDTO)
        {
            using (var context = new DaoContext())
            {
                context.Product.Remove(context.Product.FirstOrDefault(p => p.ID == productDTO));
                context.SaveChanges();

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
                    bar_code = this.bar_code,
                };

                context.Product.Add(product);

                context.SaveChanges();

                id = product.ID;

            }
            return id;
        }

        public static void update(int id, ProductDTO productDTO)
        {
            using (var context = new DaoContext())
            {
                var product = context.Product.FirstOrDefault(a => a.ID == id);

                if (product != null)
                {
                    if (productDTO.name != null)
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

        public ProductDTO findById(int id)
        {

            return new ProductDTO();
        }

        public List<ProductDTO> getAll()
        {
            return this.productsDTO;
        }


        public ProductDTO convertModelToDTO()
        {
            var productDTO = new ProductDTO();

            productDTO.name = this.name;

            productDTO.bar_code = this.bar_code;

            return productDTO;
        }

        public static int findId(string bar_code)
        {
            using(var context = new DaoContext())
            {
                var product = context.Product.FirstOrDefault(S => S.bar_code == bar_code);
                return product.ID;
            }
        }

        public static int find(ProductDTO product)
        {
            using (var context = new DaoContext())
            {
                var products = context.Product.FirstOrDefault(s => s.bar_code == product.bar_code);
                return products.ID;
            }
        }



        public void setName(string nome)
        {
            this.name = nome;
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

    }
}
