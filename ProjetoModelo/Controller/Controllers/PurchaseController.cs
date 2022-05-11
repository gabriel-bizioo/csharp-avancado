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
        [Route("getClient/{ClientID}")]
        public void getClientPurchases(int ClientID)
        {
            
            
        }

        [HttpGet]
        [Route("getStore/{storeID}")]
        public void getStorePurchases()
        {
            
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
                purchase_client = purchase.getClient().getName(),
                purchase_store = purchase.getStore().getName()
            };

        }
        
    }
}