using WebApplication4.Models;
namespace WebApplication4.Services;

public class CalculateService
{
    
    
    public decimal GetTotalAmount(List<Fruit> fruits) 
    {
        return fruits.Sum(fruit => fruit.Price);
    }
}