using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers
{
    [ApiController]
    [Route("wishlist")]
    public class WishListController
    {
        [HttpPost]
        [Route("create/{clientinfo}/{productinfo}")]
        public void CreateWishlist(string clientinfo, string productinfo)
        {
            WishList.Create(clientinfo, productinfo);
        }

        [HttpDelete]
        [Route("remove/{clientinfo}/{productinfo}")]
        public void RemoveWishList(string clientinfo, string productinfo)
        {
            WishList.Delete(clientinfo, productinfo);
        }      

        [HttpGet]
        [Route("getproducts/{ClientId}")]
        public List<object> GetProducts(int ClientId)
        {
            return WishList.GetAllProducts(ClientId);
        }  
    }
}