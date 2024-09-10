using System.Text.Json;

namespace WebApplication4.Models;

public class FruitFactory
{
    private readonly Dictionary<string, Func<Fruit>> _fruitMap = new()
    {
        {"apple", () => new Apple()},
        {"grape", () => new Grape()},
        {"orange", () => new Orange()},
    };

    public Fruit CreateFruit(string fruitName)
    {
        if (_fruitMap.TryGetValue(fruitName, out var fruitFactory))
        {
            return fruitFactory();
        }

        throw new JsonException($"Unknown Fruit: {fruitName}");
    }
    
}