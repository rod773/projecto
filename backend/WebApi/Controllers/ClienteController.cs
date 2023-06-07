using WebApi.Models;
using WebApi.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IServicioCliente _servicioCliente;



        public ClienteController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }




        [HttpGet("GetClientes")]
        public async Task<ActionResult> GetClientes()
        {
            try
            {

                var clientes = await _servicioCliente.GetClientes();
                return Ok(clientes);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost("PostClientes")]
        public async Task<ActionResult> PostCliente(
            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais

          )
        {
            try
            {

                var res = await _servicioCliente.AgregarCliente(

                    Nombres,
                    Apellidos,
                    Telefono,
                    Email,
                    Pais

                    );



                return Ok(res);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("PutCliente")]

        public async Task<IActionResult> UpdateCliente(
            int IdCliente,
            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais,
            string FechaCreacion
            )
        {
            try
            {

                await _servicioCliente.ActualizarCliente(
                IdCliente,
                Nombres,
                Apellidos,
                Telefono,
                Email,
                Pais,
                FechaCreacion
                );

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("DeleteCliente")]
        public async Task<ActionResult> DeleteCliente(int id)
        {
            try
            {

                var res = await _servicioCliente.BorrarCliente(id);


                return Ok(res);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
    }
}
