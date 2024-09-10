using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services;

namespace WebApplication4.Controllers;

[Microsoft.AspNetCore.Components.Route("[controller]")]
public class FruitController(CalculateService calculateService) : ControllerBase
{
    [HttpGet]
   [Route("Hello")]
   public string Hello()
   {
       return "Hello!!!!";
   }

   [HttpPost]
   [Route("TotalAmount")]
   public ActionResult<decimal> TotalAmount([FromBody] List<Fruit> fruits) 
   {
       var service = new CalculateService();
       service.GetTotalAmount(fruits);
       var totalAmount = calculateService.GetTotalAmount(fruits);
       return Ok(totalAmount);
   }
}