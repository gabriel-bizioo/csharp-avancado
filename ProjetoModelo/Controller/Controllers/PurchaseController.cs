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

        [HttpPost]
        [Route("register")]
        public object requestClientPurchase([FromBody]PurchaseDTO purchaseDTO)
        {   
            var purchase = model.Purchase.convertDTOToModel(purchaseDTO);
            
            return new
            {
                purchase_date = purchaseDTO.purchase_date,
                confirmation_number = purchaseDTO.confirmation_number,
                number_nf = purchaseDTO.number_nf,
                payment_type = purchaseDTO.payment_type,
                purchase_status = purchaseDTO.purchase_status,
                purchase_value = purchaseDTO.purchase_value,
                store = purchaseDTO.store,
                client = purchaseDTO.client,
                products = purchaseDTO.purchase_products
            };
        }

        
        public void getStorePurchase()
        {

        }

        public void makePurchase()
        {

        }
        
    }
}