using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskAPI
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private string jwtKey = "<:R_PKp}6<B\"m-*4A)YGu//w3.i1hw{2/Aw-H2\"0";
        private readonly string _jwtIssuer = "TuAplicacion";

        private static List<User> users = new(); // Base de datos ficticia para almacenar usuarios

        [HttpPost("register")]
        public IActionResult Register(UserRegisterRequest request)
        {
            // Verificar si el usuario ya existe
            if (users.Any(u => u.Username == request.Username))
                return BadRequest("El usuario ya existe.");

            // Guardar el nuevo usuario (clave simplificada, NO recomendado en producción)
            users.Add(new User { Username = request.Username, Password = request.Password });

            return Ok("Usuario registrado exitosamente.");
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequest request)
        {
            // Validar credenciales
            var user = users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if (user == null)
                return Unauthorized("Credenciales inválidas.");

            // Generar JWT
            var token = GenerateJwtToken(request.Username);
            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtIssuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    // Clases auxiliares para las solicitudes
    public class UserRegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}