using Microsoft.AspNetCore.Mvc;
using DTO;

namespace Controller.Controllers;

[ApiController]
[Route("stocks")]

public class StocksController : ControllerBase
{

    [HttpPost]
    [Route("register")]
    public void addProductToStock(Object request)
    {

    }

    [HttpPut]
    [Route("update")]
    public void updateStock(Object request) { }
}