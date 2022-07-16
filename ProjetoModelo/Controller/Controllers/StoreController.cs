using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController : ControllerBase
    {

        [HttpGet]
        [Route("getall")]
        public IActionResult getAllStores()
        {
            var storelist = model.Store.getAllStores();
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            var result = new ObjectResult(storelist);
            
            return result; 
        }
        
        [Authorize]
        [HttpPost]
        [Route("register")]
        public IActionResult registerStore([FromBody] StoreDTO storeDTO)
        {
            var store = model.Store.convertDTOToModel(storeDTO);

            int id = store.Save();

            var NewStore = new
            {
                owner = storeDTO.Owner,
                name = storeDTO.name,
                cnpj = storeDTO.CNPJ,
                purchases = storeDTO.purchases,
                id = id
            };

            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            var result = new ObjectResult(NewStore);
            
            return result;
        }
        
        [HttpGet]
        [Route("get/{storeID}")]
        public IActionResult getStoreInformation(int storeID)
        {
            var StoreInfo = model.Store.find(storeID);
            
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var result = new ObjectResult(StoreInfo);

            return result;
        }

    }
}