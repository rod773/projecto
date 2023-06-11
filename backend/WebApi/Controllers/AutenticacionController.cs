using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using WebApi.Servicios.Interfaces;
using System.Text;
using WebApi.Servicios;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {   
        private readonly string? secretKey;

        private readonly List<Usuario> usuarios;

        private readonly IServicioAutenticacion _servicioAutenticacion;

       


        public AutenticacionController(IConfiguration config, IServicioAutenticacion servicioAutenticacion)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
            _servicioAutenticacion = servicioAutenticacion;

            usuarios = (List<Usuario>?)_servicioAutenticacion.GetUsuarios().Result;


          }


        

        private string ConvertMd5(string pass)
        {
           

            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dataMd5.Length; i++)
             sb.AppendFormat("{0:x2}", dataMd5[i]);


            return sb.ToString();
            

            
        }

       

        [HttpPost]
        [Route("Validar")]
        public  IActionResult Validar([FromBody] Usuario request)
        {
            try
            {
                Boolean autenticado = false;

                foreach (var usuario in usuarios)
                {
                    if (
                    request.correo.Equals(usuario.correo)
                     

                    && ConvertMd5(request.clave).Equals(usuario.clave)
                      
                    )

                    autenticado = true;
                }

                
                
                if (autenticado)
                  {

                    var keyBytes = Encoding.ASCII.GetBytes(secretKey);
                    var claims = new ClaimsIdentity();
                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, request.correo));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string tokencreado = tokenHandler.WriteToken(tokenConfig);


                    return StatusCode(StatusCodes.Status200OK, new { token = tokencreado });

                }
                else
                {

                    return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
                }

            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
            
        }


        //*****************************************


        [HttpGet]
        [HttpGet("GetUsuarios")]
        public async Task<ActionResult> GetUsuarios()
        {
            try
            {

                var usuarios = await _servicioAutenticacion.GetUsuarios();
                return Ok(usuarios);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


    }
}
