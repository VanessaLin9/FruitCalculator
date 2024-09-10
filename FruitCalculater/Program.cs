using System.Text.Json.Serialization;
using WebApplication4.Controllers;
using WebApplication4.Models;
using WebApplication4.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<FruitFactory>();

builder.Services.AddSingleton<JsonConverter<Fruit>>(provider =>
{
    var fruitFactory = provider.GetRequiredService<FruitFactory>();
    return new FruitConverter(fruitFactory);
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            builder.Services.BuildServiceProvider().GetRequiredService<JsonConverter<Fruit>>()
        );
    });
builder.Services.AddTransient<CalculateService>();
builder.Services.AddTransient<FruitController>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapGet("/", ()=> Results.Redirect("/swagger/index.html"));
app.MapControllers();
app.Run();
