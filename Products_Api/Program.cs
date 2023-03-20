using Customer_Api.Models;
using Microsoft.EntityFrameworkCore;
using Products_Api.Data_Access;
using Products_Api.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MicroserviceContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));
builder.Services.AddScoped<IProductcs,ProductRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("gateway", builde =>
    {
        builde.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseCors("gateway");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
