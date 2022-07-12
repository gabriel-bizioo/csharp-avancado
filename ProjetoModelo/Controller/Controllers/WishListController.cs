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
        public object CreateWishlist(string clientinfo, string productinfo)
        {
            if(WishList.Create(clientinfo, productinfo))
            {
                return new
                {
                    status = "product added"
                };
            }
            else
            {
               WishList.Delete(clientinfo, productinfo);

               return new
               {
                    status = "product removed"
               };
            }
        }

        [HttpDelete]
        [Route("remove/{clientinfo}/{productinfo}")]
        public object RemoveWishList(string clientinfo, string productinfo)
        {
            WishList.Delete(clientinfo, productinfo);

            return new
            {
                status = "product removed"
            };
        }      

        [HttpGet]
        [Route("getproducts/{ClientId}")]
        public List<object> GetProducts(int ClientId)
        {
            return WishList.GetAllProducts(ClientId);
        }  
    }
}