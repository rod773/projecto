using Microsoft.AspNetCore.Mvc;
using CrudDapper.Repositorio;
using CrudDapper.Models;


namespace crudDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public IConfiguration Configuration { get;  }

        public ClienteController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet("GetClientes")]
        public List<Cliente> GetClientes()
        {

            string? conn = Configuration.GetConnectionString("Default");

            Repositorio repo = new Repositorio(conn);


            return repo.GetClientes();
        }
    }
}
