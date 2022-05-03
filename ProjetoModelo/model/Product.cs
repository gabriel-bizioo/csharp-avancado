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

        public void delete(ProductDTO obj)
        {
            using (var context = new DaoContext())
            {
                     var product =  context.Product.FirstOrDefault(/*x => x.ID = id*/);
                     context.Product.Remove(product);
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

        public void update(ProductDTO obj)
        {

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
