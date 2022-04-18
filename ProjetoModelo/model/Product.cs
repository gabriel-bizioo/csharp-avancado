using Interfaces;

namespace model
{
    public class Product : IValidateDataObject<Product>
    {
        string nome;
        string bar_code;

        public void setName(string nome)
        {
            this.nome = nome;
        }

        public void setBarCode(string barcode)
        {
            this.bar_code = barcode;
        }

        public string getName()
        {
            return nome;
        }

        public string getBarCode()
        {
            return bar_code;
        }

        public Boolean validateObject(Product product)
        {
            if(nome == null)return false;

            if(bar_code == null) return false;

            return true;
        }

    }
}
