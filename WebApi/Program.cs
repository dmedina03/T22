using Microsoft.EntityFrameworkCore;
using Aplication.Extensions;
using Persistence.Context;
using System.Text.Json.Serialization;
using Azure.Identity;
using Aplication.Utilities;
using Aplication.Utilities.Middleware;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var keyvaulturl = builder.Configuration.GetSection("environmentVariables:KeyVaultUrl").Value!.ToString();
var keyvaultid = builder.Configuration.GetSection("environmentVariables:ClientId").Value!.ToString();
var keyvaultclient = builder.Configuration.GetSection("environmentVariables:ClientSecret").Value!.ToString();
var DirectoryId = builder.Configuration.GetSection("environmentVariables:DirectoryId").Value!.ToString();


//conexion ventanilla vt
builder.Configuration.AddAzureKeyVault(
new Uri(keyvaulturl),
new ClientSecretCredential(DirectoryId, keyvaultid, keyvaultclient));

// captura de cadena de conexion
var mysql = builder.Configuration.GetSection(KeyVault.SQLDBManipAli).Value;


builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(mysql));

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("CONNECTION_STRING"));
//});

//Inyeccion de dependencias
builder.Services.AddInterfacesInjection();
builder.Services.AddServiceDependency();
//Injection Services FluentValidation
builder.Services.AddServicesValidation();

//Configuracion de cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(myAllowSpecificOrigins,
        builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
    context.EnsureSeed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
