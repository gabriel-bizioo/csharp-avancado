using Microsoft.AspNetCore.Mvc;
using DTO;
using model;

namespace Controller.Controllers
{
    [ApiController]
    [Route("purchase")]
    public class PurchaseController
    {
        [HttpGet]
        [Route("getclient/{clientinfo}")]
        public IEnumerable<object> getClientPurchases(string clientinfo)
        {
            return model.Purchase.getClientPurchases(clientinfo);
        }

        [HttpGet]
        [Route("getstore/{storeinfo}")]
        public IEnumerable<object> getStorePurchases(string storeinfo)
        {
            return model.Purchase.getStorePurchases(storeinfo);
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