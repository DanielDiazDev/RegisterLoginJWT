

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RegisterLoginJWT.API.MapperProfile;
using RegisterLoginJWT.Data;
using RegisterLoginJWT.Data.Settings;
using RegisterLoginJWT.Service;
using RegisterLoginJWT.Service.Interfaces;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var key = builder.Configuration["Jwt:Secret"];

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDataServices(builder.Configuration); //Inyectamos las dependencias aqui
builder.Services.AddServicesConfiguration(builder.Configuration); //Inyectamos las dependencias aqui
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);

    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        IssuerSigningKey = signingKey
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
//builder.Services.AddAuthorization();
//builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
//{
//    var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); //Guardar la firma en byte
//    var signingCredential = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateAudience = false,
//        ValidateIssuer = false,
//        IssuerSigningKey = signingKey,
//    };
//});