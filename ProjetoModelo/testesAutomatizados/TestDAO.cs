using NUnit.Framework;
using System.Collections.Generic;
using System;
using DTO;
using System.Linq;
using DAO;
using model;
using System.Threading;

namespace testesAutomatizados
{

    public class TestDAO 
    {
        [Test]
        public void insertAddress()
        {
            var id=0;

            var addressDTO  =  new AddressDTO();

            addressDTO.street = "rua 1";

            addressDTO.state = "estado 1";

            addressDTO.city  = "cidade 1";

            addressDTO.country = "pais 1";

            addressDTO.poste_code = "12545215";

            var addressModel = model.Address.convertDTOToModel(addressDTO);

            if(addressModel.validateObject()){
                id = addressModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));
        }

       [Test]
        public void insertClient()
        {
            var id = 0;

            var addressDTO  =  new AddressDTO();

            addressDTO.street = "rua cliente 1";

            addressDTO.state = "estado cliente 1";

            addressDTO.city  = "cidade cliente 1";

            addressDTO.country = "pais cliente 1";

            addressDTO.poste_code = "12cliente5";


            var clientDTO = new ClientDTO();

            clientDTO.name = "João Batista";

            clientDTO.email = "joao.batista@email.com";

            clientDTO.login = "joao.batista@email.com";

            clientDTO.address = addressDTO;

            clientDTO.password = "sdfsdgfgd";

            clientDTO.phone = "41999999999";

            clientDTO.document = "85214789455";
            
            clientDTO.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            var clientModel = model.Client.convertDTOToModel(clientDTO);

            if(clientModel.validateObject()){
                id = clientModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO2  =  new AddressDTO();

            addressDTO2.street = "rua cliente 2";

            addressDTO2.state = "estado cliente 2";

            addressDTO2.city  = "cidade cliente 2";

            addressDTO2.country = "pais cliente 2";

            addressDTO2.poste_code = "34cliente5";


            var clientDTO2 = new ClientDTO();

            clientDTO2.name = "Roberto Alves";

            clientDTO2.email = "roberto.alves@email.com";

            clientDTO2.login = "roberto.alves@email.com";

            clientDTO2.address = addressDTO2;

            clientDTO2.password = "dfsrtsfderf";

            clientDTO2.phone = "419999888888";

            clientDTO2.document = "852147896";
            
            clientDTO2.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);
            

            clientModel = model.Client.convertDTOToModel(clientDTO2);

            if(clientModel.validateObject()){
                id = clientModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO3  =  new AddressDTO();

            addressDTO3.street = "rua cliente 1";

            addressDTO3.state = "estado cliente 1";

            addressDTO3.city  = "cidade cliente 1";

            addressDTO3.country = "pais cliente 1";

            addressDTO3.poste_code = "12cliente5";

            var clientDTO3 = new ClientDTO();

            clientDTO3.name = "Bento Cabral";

            clientDTO3.email = "bento.cabral@email.com";

            clientDTO3.login = "bento.cabral@email.com";

            clientDTO3.address = addressDTO3;

            clientDTO3.password = "sdfsdgfgd";

            clientDTO3.phone = "41999999999";

            clientDTO3.document = "984563258";
            
            clientDTO3.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            clientModel = model.Client.convertDTOToModel(clientDTO3);

            if(clientModel.validateObject()){
                id = clientModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO4  =  new AddressDTO();

            addressDTO4.street = "rua cliente 1";

            addressDTO4.state = "estado cliente 1";

            addressDTO4.city  = "cidade cliente 1";

            addressDTO4.country = "pais cliente 1";

            addressDTO4.poste_code = "12cliente5";


            var clientDTO4 = new ClientDTO();

            clientDTO4.name = "Maria Aparecida";

            clientDTO4.email = "maria.aparecida@email.com";

            clientDTO4.login = "maria.aparecida@email.com";

            clientDTO4.address = addressDTO4;

            clientDTO4.password = "sdfsdgfgd";

            clientDTO4.phone = "41999999999";

            clientDTO4.document = "951756324";
            
            clientDTO4.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            clientModel = model.Client.convertDTOToModel(clientDTO4);

            if(clientModel.validateObject()){
                id = clientModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO5  =  new AddressDTO();

            addressDTO5.street = "rua cliente 1";

            addressDTO5.state = "estado cliente 1";

            addressDTO5.city  = "cidade cliente 1";

            addressDTO5.country = "pais cliente 1";

            addressDTO5.poste_code = "12cliente5";


            var clientDTO5 = new ClientDTO();

            clientDTO5.name = "Beatriz Silva";

            clientDTO5.email = "beatriz.silva@email.com";

            clientDTO5.login = "beatriz.silva@email.com";

            clientDTO5.address = addressDTO5;

            clientDTO5.password = "sdfsdgfgd";

            clientDTO5.phone = "41999999999";

            clientDTO5.document = "753256842";
            
            clientDTO5.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            clientModel = model.Client.convertDTOToModel(clientDTO5);

            if(clientModel.validateObject()){
                id = clientModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));
        }

        [Test]
        public void insertOwner()
        {
            var id = 0;

            var addressDTO  =  new AddressDTO();

            addressDTO.street = "rua owner 1";

            addressDTO.state = "estado owner 1";

            addressDTO.city  = "cidade owner 1";

            addressDTO.country = "pais owner 1";

            addressDTO.poste_code = "12owner5";


            var ownerDTO = new OwnerDTO();

            ownerDTO.name = "Carlos Ribeiro";

            ownerDTO.email = "carlos.ribeiro@email.com";

            ownerDTO.login = "carlos.ribeiro@email.com";

            ownerDTO.address = addressDTO;

            ownerDTO.password = "sdfsdgfgd";

            ownerDTO.phone = "41999999999";

            ownerDTO.document = "95147853228";
            
            ownerDTO.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);
          
            var ownerModel = model.Owner.convertDTOToModel(ownerDTO);

            if(ownerModel.validateObject()){
                id = ownerModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO2  =  new AddressDTO();

            addressDTO2.street = "rua owner 2";

            addressDTO2.state = "estado owner 2";

            addressDTO2.city  = "cidade owner 2";

            addressDTO2.country = "pais owner 2";

            addressDTO2.poste_code = "2352owner5";


            var ownerDTO2 = new OwnerDTO();

            ownerDTO2.name = "Beatriz Silva";

            ownerDTO2.email = "beatriz.silva@email.com";

            ownerDTO2.login = "beatriz.silva@email.com";

            ownerDTO2.address = addressDTO2;

            ownerDTO2.password = "sdfsdgfgd";

            ownerDTO2.phone = "41999999999";

            ownerDTO2.document = "325412587458";
            
            ownerDTO2.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            ownerModel = model.Owner.convertDTOToModel(ownerDTO2);

            if(ownerModel.validateObject()){
                id = ownerModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO3  =  new AddressDTO();

            addressDTO3.street = "rua owner 1";

            addressDTO3.state = "estado owner 1";

            addressDTO3.city  = "cidade owner 1";

            addressDTO3.country = "pais owner 1";

            addressDTO3.poste_code = "12owner5";


            var ownerDTO3 = new OwnerDTO();

            ownerDTO3.name = "Bento Cabral";

            ownerDTO3.email = "bento.cabral@email.com";

            ownerDTO3.login = "bento.cabral@email.com";

            ownerDTO3.address = addressDTO;

            ownerDTO3.password = "sdfsdgfgd";

            ownerDTO3.phone = "41999999999";

            ownerDTO3.document = "78546985214";
            
            ownerDTO3.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            ownerModel = model.Owner.convertDTOToModel(ownerDTO3);

            if(ownerModel.validateObject()){
                id = ownerModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

            var addressDTO4  =  new AddressDTO();

            addressDTO4.street = "rua owner 1";

            addressDTO4.state = "estado owner 1";

            addressDTO4.city  = "cidade owner 1";

            addressDTO4.country = "pais owner 1";

            addressDTO4.poste_code = "12owner5";


            var ownerDTO4 = new OwnerDTO();

            ownerDTO4.name = "Maria Aparecida";

            ownerDTO4.email = "maria.aparecida@email.com";

            ownerDTO4.login = "maria.aparecida@email.com";

            ownerDTO4.address = addressDTO;

            ownerDTO4.password = "sdfsdgfgd";

            ownerDTO4.phone = "41999999999";

            ownerDTO4.document = "52145632258";
            
            ownerDTO4.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            ownerModel = model.Owner.convertDTOToModel(ownerDTO4);

            if(ownerModel.validateObject()){
                id = ownerModel.save();
            }

            Assert.That(id, Is.Not.EqualTo(0));

        }
        [Test]
        public void insertStore()
        {
            List<StoreDTO> stores = new List<StoreDTO>();
           
            var storeDTO = new StoreDTO();

            storeDTO.name = "Loja 99";

            storeDTO.cnpj = "0659865623";      

            var storeDTO1 = new StoreDTO();

            storeDTO1.name = "Loja 98";

            storeDTO1.cnpj = "52647825458";      

            var storeDTO2 = new StoreDTO();

            storeDTO2.name = "Loja 97";

            storeDTO2.cnpj = "97586425832";      

            var storeDTO3 = new StoreDTO();

            storeDTO3.name = "Loja 96";

            storeDTO3.cnpj = "587458965412";      

            var storeDTO4 = new StoreDTO();

            storeDTO4.name = "Loja 95";

            storeDTO4.cnpj = "31897456853458";      

            stores.Add(storeDTO1);

            stores.Add(storeDTO2);

            stores.Add(storeDTO3);

            stores.Add(storeDTO4);

            var id  = 0;

            int  dono = 1;

            foreach(var str in stores){

                var storeModel = model.Store.convertDTOToModel(str);               

                if(storeModel.validateObject()){
                    id = storeModel.save(dono);
                }

                dono++;

                Assert.That(id, Is.Not.EqualTo(0));

                id = 0;

            }         

        }

        [Test]
        public void insertProduct()
        {
            List<ProductDTO> produtos = new List<ProductDTO>();

            var productDTO1 = new ProductDTO();

            productDTO1.name = "produto 1";

            productDTO1.bar_code = "12521142521252325";

            produtos.Add(productDTO1);

             var productDTO2 = new ProductDTO();

            productDTO2.name = "produto 2";

            productDTO2.bar_code = "7854687654865";

            produtos.Add(productDTO2);


            var productDTO3 = new ProductDTO();

            productDTO3.name = "produto 3";

            productDTO3.bar_code = "4524112588543164";

            produtos.Add(productDTO3);


            var productDTO4 = new ProductDTO();

            productDTO4.name = "produto 4";

            productDTO4.bar_code = "632154584531685";

            produtos.Add(productDTO4);


            var productDTO5 = new ProductDTO();

            productDTO5.name = "produto 5";

            productDTO5.bar_code = "421324862132465";

            produtos.Add(productDTO5);

            var id = 0;

            foreach(var prod in produtos){

                var productModel = model.Product.convertDTOToModel(prod);               

                if(productModel.validateObject()){

                    id = productModel.save();

                }

                Assert.That(id, Is.Not.EqualTo(0));

                id= 0;
            }          

        }

        [Test]
        public void insertStocks()
        {   
            int id = 0;
            for(int i = 1; i<5; i++){
                for(int j = 1; j<6; j++){
                    if(i==j){
                        continue;
                    }
                    model.Stocks stc  = new model.Stocks();

                    double unit = (i*j*3.14);

                    id = stc.save(i, j, i+j, unit);

                    Assert.That(id, Is.Not.EqualTo(0));

                    id=0;
                }
            }
           
        }

        [Test]
        public void insertWishList()
        {
            int id = 0;

            using(var context = new DaoContext())
            {
                for(int client= 1; client < 5; client++){
                    var cliente = context.Client.Where(c=> c.ID == client).Single();
                    for(int product = 1; product<5;product++){
                        var wishList = new model.WishList();

                        id = wishList.save(cliente.ID, product);

                        Assert.That(id, Is.Not.EqualTo(0));

                        id=0;
                    }
                }
            }          

        }

        [Test]
        public void insertPurchase()
        {
            var id = 0;
            
            var purchaseDTO = new PurchaseDTO();

            purchaseDTO.purchase_date = new DateTime(2022, 4, 1, 8, 30, 3);

            purchaseDTO.number_confirmation = "1258458785254";

            purchaseDTO.number_nf = "5246824687";
            
            purchaseDTO.payment_type = 2;

            purchaseDTO.purchase_status = 1;

            purchaseDTO.purchase_value = 25.00;
            
            var productDTO1 = new ProductDTO();

            productDTO1.name = "produto 1";

            productDTO1.bar_code = "12521142521252325";

            purchaseDTO.products.Add(productDTO1);

            var productDTO2 = new ProductDTO();

            productDTO2.name = "produto 2";

            productDTO2.bar_code = "7854687654865";

            purchaseDTO.products.Add(productDTO2);
     

            var productDTO4 = new ProductDTO();

            productDTO4.name = "produto 4";

            productDTO4.bar_code = "632154584531685";

            purchaseDTO.products.Add(productDTO4);      

            var storeDTO1 = new StoreDTO();

            storeDTO1.name = "Loja 98";

            storeDTO1.cnpj = "52647825458";

            var addressDTO5 = new AddressDTO();

            addressDTO5.street = "rua cliente 1";

            addressDTO5.state = "estado cliente 1";

            addressDTO5.city = "cidade cliente 1";

            addressDTO5.country = "pais cliente 1";

            addressDTO5.poste_code = "12cliente5";

            var clientDTO5 = new ClientDTO();

            clientDTO5.name = "Beatriz Silva";

            clientDTO5.email = "beatriz.silva@email.com";

            clientDTO5.login = "beatriz.silva@email.com";

            clientDTO5.password = "sdfsdgfgd";

            clientDTO5.phone = "41999999999";

            clientDTO5.address = addressDTO5;

            clientDTO5.document = "753256842";
            
            clientDTO5.date_of_birth = new DateTime(2002, 5, 1, 8, 30, 30);

            purchaseDTO.client = clientDTO5;

            purchaseDTO.store = storeDTO1;

            var purchase = model.Purchase.convertDTOToModel(purchaseDTO);

            if(purchase.validateObject()){
                id=purchase.save();
            }
            Assert.That(id, Is.Not.EqualTo(0));
        }
    }
}