using BasketballAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddScoped<BasketballService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
