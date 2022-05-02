using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController
    {
        [HttpPost]
        [Route("register")]
        public object registerStore([FromBody] StoreDTO storeDTO)
        {
            var store = model.Store.convertDTOToModel(storeDTO);

            //int id = store.save(store.owner.save());

            return new 
            {
                owner = storeDTO.Owner,
                name = storeDTO.name,
                cnpj = storeDTO.CNPJ,
                purchases = storeDTO.purchases,
                //id = id
            };
        }
        
        public void getAllStore()
        {
            
        }
    

        public void getStoreInformation()
        {
        
        }

    }
}