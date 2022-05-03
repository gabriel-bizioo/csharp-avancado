using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("purchase")]

public class PurchaseController : ControllerBase
{
    //[HttpPost]
    //[Route("register")]
    //public object registerPurchase([FromBody] PurchaseDTO purchase)
    //{
    //    var purchaseModel = model.Purchase.convertDTOToModel(purchase);
    //    var id = purchaseModel.save();
    //    return new
    //    {
    //        purchaseDate = purchase.purchase_date,
    //        numberConfirmation = purchase.number_confirmation,
    //        numberNf = purchase.number_nf,
    //        purchaseStatus = purchase.purchase_status,
    //        paymentType = purchase.payment_type,
    //        purchaseValue = purchase.purchase_value,
    //        products = purchase.products,
    //        client = purchase.client,
    //        store = purchase.store,

    //        id = id
    //    };
    //}

    [HttpGet]
    [Route("getClient/{clientID}")]
    public object getClientPurchase(int clientID)
    {
        var clientPurchase = model.Purchase.getClientPurchases(clientID);
        return clientPurchase;
    }

    [HttpGet]
    [Route("getStore/{storeID}")]
    public object getStorePurchase(int storeID) 
    {
        var storePurchase = model.Purchase.getStorePurchases(storeID);
        return storePurchase;
    }

    [HttpPost]
    [Route("make/{clientID}/{storeID}/{productID}")]
    public object makePurchase(PurchaseDTO purchase, int clientID, int storeID, int productID)
    {
        var purchaseModel = model.Purchase.convertDTOToModel(purchase);
        var id = purchaseModel.save(clientID, storeID, productID);
        return new
        {
            purchaseDate = purchase.purchase_date,
            numberConfirmation = purchase.number_confirmation,
            numberNf = purchase.number_nf,
            purchaseStatus = purchase.purchase_status,
            paymentType = purchase.payment_type,
            purchaseValue = purchase.purchase_value,
            products = purchase.products,
            client = purchase.client,
            store = purchase.store,

            id = id
        };
    }

}