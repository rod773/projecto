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


        [HttpPost("PostClientes")]
        public Cliente PostCliente(
            string Nombres,
            string Aoellidos,
            int Telefono,
            string Email,
            string Pais
            
          )
        {
            string? conn = Configuration.GetConnectionString("Default");
            Repositorio repo = new Repositorio(conn);

            Cliente cliente = new Cliente();

            cliente .Nombres = Nombres;
            cliente.Apellidos = Aoellidos;
            cliente.Telefono = Telefono;
            cliente.Email= Email;   
            cliente.Pais = Pais;
           


            return repo.AgregarCliente(cliente);
        }
    }
}
