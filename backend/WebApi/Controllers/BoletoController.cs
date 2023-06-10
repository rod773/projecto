using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Servicios.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {

        private readonly IServicioCliente _servicioCliente;



        public BoletoController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }



        [HttpGet("GetBoletos")]
        public async Task<ActionResult> GetBoletos()
        {
            try
            {

                var boletos = await _servicioCliente.GetBoletos();
                return Ok(boletos);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet("GetBoletosCliente")]
        public async Task<ActionResult> GetBoletosCliente(int id)
        {
            try
            {

                var boletos = await _servicioCliente.GetBoletosCliente(id);
                return Ok(boletos);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


    }
}
