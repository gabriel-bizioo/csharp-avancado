using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("purchase")]
    public class PurchaseController
    {
        [HttpGet]
        [Route("getclient/{clientID}")]
        public List<object> getClientPurchases(int clientID)
        {
            return model.Purchase.getClientPurchases(clientID);
        }

        [HttpGet]
        [Route("getstore/{storeID}")]
        public List<object> getStorePurchases(int storeID)
        {
            return model.Purchase.getStorePurchases(storeID);
        }

        [HttpPost]
        [Route("create/{storeinfo}/{productinfo}/{clientinfo}")]
        public void makePurchase([FromBody] PurchaseDTO purchaseDTO, string storeinfo, string productinfo, string clientinfo)
        {
            var purchase = Purchase.convertDTOToModel(purchaseDTO);

            purchase.Create(storeinfo, productinfo, clientinfo);

        }

        [HttpGet]
        [Route("getpurchase/{id}")]
        public object GetPurchase(int id)
        {
            return model.Purchase.findById(id);
        }   
    }
}