using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskAPI.Data;
using TaskAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

var jwtKey = "<:R_PKp}6<B\"m-*4A)YGu//w3.i1hw{2/Aw-H2\"0"; // Misma clave que en la configuración
var jwtIssuer = "TuAplicacion";

// Agregar servicios al contenedor.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Esquema predeterminado para autenticar
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;   // Esquema para desafíos
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();


//var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
//var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//var tokenDescriptor = new SecurityTokenDescriptor
//{
//    Subject = new System.Security.Claims.ClaimsIdentity(new[]
//    {
//        new System.Security.Claims.Claim("sub", "usuario_id")
//    }),
//    Expires = DateTime.UtcNow.AddHours(1),
//    Issuer = jwtIssuer,
//    Audience = jwtIssuer,
//    SigningCredentials = credentials
//};

//var tokenHandler = new JwtSecurityTokenHandler();
//var token = tokenHandler.CreateToken(tokenDescriptor);
//var jwt = tokenHandler.WriteToken(token);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();