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

        [HttpGet("GetCliente")]
        public async Task<ActionResult> GetCliente(int id)
        {
            try
            {

                var cliente = await _servicioCliente.GetCliente(id);
                return Ok(cliente);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


        [HttpPost("PostCliente")]
        public async Task<ActionResult> PostCliente([FromBody] ClienteNuevo clientenuevo)
        {
            try
            {


                var res = await _servicioCliente.AgregarCliente(clientenuevo);



                return Ok(res);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("PutCliente")]

        public async Task<IActionResult> UpdateCliente(Cliente cliente)
        {
            try
            {

                await _servicioCliente.ActualizarCliente(cliente);

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
