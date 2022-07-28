using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{
    [ApiController]
    [Route("purchase")]
    public class PurchaseController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("getclient/{clientinfo}")]
        public IActionResult getClientPurchases(string clientinfo)
        {
            var Purchases = model.Purchase.getClientPurchases(clientinfo);
            
            var result = new ObjectResult(Purchases);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("getowner/{ownerinfo}")]
        public IActionResult getOwnerPurchases(string ownerinfo)
        {
            var Purchases = model.Purchase.getOwnerPurchases(ownerinfo);

            var result = new ObjectResult(Purchases);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("getstore/{storeinfo}")]
        public IActionResult getStorePurchases(string storeinfo)
        {
            var StorePurchases = model.Purchase.getStorePurchases(storeinfo);
            
            var result = new ObjectResult(StorePurchases);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpPost]
        [Route("create/{storeinfo}")]
        public IActionResult makePurchase([FromBody] PurchaseDTO purchaseDTO, int storeinfo)
        {
            var purchase = Purchase.convertDTOToModel(purchaseDTO);

            bool successful = false;
            if(purchase.Create(storeinfo))
            {
                successful = true;
            }
            
            var result = new ObjectResult(successful);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }

        [Authorize]
        [HttpGet]
        [Route("getpurchase/{id}")]
        public IActionResult GetPurchase(int id)
        {
            var Purchases = model.Purchase.findById(id);
            
            var result = new ObjectResult(Purchases);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return result;
        }   
    }
}