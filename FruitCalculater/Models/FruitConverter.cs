using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication4.Models;

public class FruitConverter(FruitFactory fruitFactory) : JsonConverter<Fruit>
{
    public override Fruit Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string fruitName = reader.GetString()!.ToLower();
            return fruitFactory.CreateFruit(fruitName);
        }
        
        throw new JsonException($"Unexpected Fruit: {reader.TokenType}");
    }


    public override void Write(Utf8JsonWriter writer, Fruit value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.GetType().Name);
    }
}