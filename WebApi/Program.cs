using ServiceContracts;
using Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

var options = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("RedisConnection")!);
options.Password = builder.Configuration["RedisPassword"]!;

ConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(options);
IDatabase database = connectionMultiplexer.GetDatabase();

builder.Services.AddSingleton<IDatabase>(database);
builder.Services.AddSingleton<ITodoService>(new TodoService(database));
builder.Services.AddControllers();
var app = builder.Build();


app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
   c.SwaggerEndpoint("/swagger/v1/swagger.json", "My TODO API using REDIS");
});


app.Run();
