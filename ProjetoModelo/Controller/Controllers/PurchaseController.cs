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
        [Route("getClient/{clientID}")]
        public void getClientPurchases()
        {
            
                
        }

        [HttpGet]
        [Route("getStore/{storeID}")]
        public void getStorePurchases()
        {

        }

        [HttpPost]
        [Route("make")]
        public void makePurchase()
        {

        }
        
    }
}