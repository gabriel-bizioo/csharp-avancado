using Interfaces;

namespace model
{
    public class Product : IValidateDataObject<Product>
    {
        string nome;
        double unit_price;
        string bar_code;

        public void setName(string nome)
        {
            this.nome = nome;
        }

        public void setUnitPrice(double unit_price)
        {
            this.unit_price = unit_price;
        }

        public void setBarCode(string barcode)
        {
            this.bar_code = barcode;
        }

        public string getName()
        {
            return nome;
        }

        public double getUnitprice()
        {
            return unit_price;
        }

        public string getBarCode()
        {
            return bar_code;
        }

        public Boolean validateObject(Product product)
        {
            if(nome == null)return false;

            if(bar_code == null) return false;

            if (unit_price <= 0) return false;

            return true;
        }

    }
}
