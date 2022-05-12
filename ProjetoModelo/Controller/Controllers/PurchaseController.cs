using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
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
        [Route("make")]
        public object makePurchase([FromBody] PurchaseDTO purchaseDTO)
        {
            var purchase = model.Purchase.convertDTOToModel(purchaseDTO);
            int id = purchase.save();

            return new
            {
                purchase_id = id,
                purchase_date = purchase.getPurchaseDate()
            };

        }
        
    }
}