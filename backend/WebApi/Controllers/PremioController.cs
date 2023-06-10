using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Servicios.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PremioController : ControllerBase
    {

        private readonly IServicioCliente _servicioCliente;



        public PremioController(IServicioCliente servicioCliente)
        {
            _servicioCliente = servicioCliente;
        }



        [HttpGet("GetPremios")]
        public async Task<ActionResult> GetPremios()
        {
            try
            {

                var premios = await _servicioCliente.GetPremios();
                return Ok(premios);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


        [HttpGet("GetPremiosCliente")]
        public async Task<ActionResult> GetPremiosCliente(int id)
        {
            try
            {

                var premios = await _servicioCliente.GetPremiosCliente(id);
                return Ok(premios);
            }

            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }

        }


    }
}
