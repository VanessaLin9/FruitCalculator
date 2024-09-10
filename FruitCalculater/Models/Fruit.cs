using System.Text.Json.Serialization;

namespace WebApplication4.Models;

[JsonConverter(typeof(FruitConverter))]
public abstract class Fruit
{
    public abstract decimal Price { get; }
}