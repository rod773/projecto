using Microsoft.AspNetCore.Mvc;
using CrudDapper.Repositorio;
using CrudDapper.Models;


namespace crudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorio _repo;

        public ClienteController(IRepositorio repo)
        {
            _repo = repo;
        }




        [HttpGet("GetClientes")]
        public async Task<ActionResult> GetClientes()
        {
            try
            {
               
                var clientes = await _repo.GetClientes();
                return Ok(clientes);
            }

            catch (Exception ex) {
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
                
                var res = await _repo.AgregarCliente(

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

        [HttpPut("PutClientes")]

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
            try {

                await  _repo.ActualizarCliente(
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

             var res =  await   _repo.BorrarCliente(id);


             return Ok(res);
            }

            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }



        }
    }
}
