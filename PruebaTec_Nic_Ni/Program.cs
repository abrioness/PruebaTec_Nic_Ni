using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTec_Nic_Ni.Models;
using System.Security.Cryptography.Xml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<LibroContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

//var PoliticasCors = "PoliticasCors";
//builder.Services.AddCors(x =>
//    {
//    x.AddPolicy(name: PoliticasCors, builder => {

//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});

//builder.Services.AddControllers().AddJsonOptions(x => {
//    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    
//}
app.UseSwagger();
app.UseSwaggerUI();

//app.UseCors(PoliticasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
