using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument();
builder.Services.AddControllers()
   .AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi3();

// Configure the HTTP request pipeline.
app.UseSwaggerUi3();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi3();
app.MapControllers();

app.Run();