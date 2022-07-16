using System;
using DTO;
using model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Controller.Controllers
{
    [ApiController]
    [Route("wishlist")]
    public class WishListController : ControllerBase
    {
        [Authorize]
        [HttpPost]
        [Route("create/{clientinfo}/{productinfo}/{storeinfo}")]
        public IActionResult CreateWishlist(string clientinfo, string productinfo, int storeinfo)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            var status = new
            {
                status = "n feiz nada"
            };
            
            if(WishList.Save(clientinfo, productinfo, storeinfo))
            {
                status =  new
                {
                    status = "product added"
                };
            }
            else
            {
               WishList.Delete(clientinfo, productinfo);

               status = new
               {
                    status = "product removed"
               };
            }
           

            var result = new ObjectResult(status);

            return result;
        }

        [Authorize]
        [HttpDelete]
        [Route("remove/{clientinfo}/{productinfo}")]
        public IActionResult RemoveWishList(string clientinfo, string productinfo)
        {
            WishList.Delete(clientinfo, productinfo);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            var status = new
            {
                status = "product removed"
            };

            var result = new ObjectResult(status);

            return result;
        }      

        [Authorize]
        [HttpGet]
        [Route("getproducts/{clientinfo}")]
        public IActionResult GetProducts(string clientinfo)
        {
            var All =  WishList.GetAllProducts(clientinfo);
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            
            var result = new ObjectResult(All);

            return result;
        }  
    }
}