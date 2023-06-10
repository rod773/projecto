using WebApi.Models;
using WebApi.Servicios.Interfaces;
using WebApi.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using System.Text;

namespace WebApi.Servicios
{
    public class ServicioCliente : IServicioCliente
    {
        

        private readonly string? _connectionString;

        private readonly IConfiguration _configuration;


        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);



        public ServicioCliente(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
            
        }


      

        public async Task ActualizarCliente(Cliente cliente)
        {
            using(var  conn = CreateConnection()) { 
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("update cliente set Nombres=@Nombres,");
            sb.AppendLine("Apellidos=@Apellidos,");
            sb.AppendLine("Email = @Email,");
            sb.AppendLine("Clave = md5(@Clave) ");
            sb.AppendLine("where idcliente = @IdCliente");

            var sql = sb.ToString ();

            var res = await conn.ExecuteAsync(
            sql, 
            new {
                @IdCliente = cliente.IdCliente,
                @Nombres = cliente.Nombres,
                @Apellidos = cliente.Apellidos,
                @Email = cliente.Email,
                @Clave = cliente.Clave,
               
            });
  
            
            }

            
        }

        public async Task<Cliente> AgregarCliente(ClienteNuevo clientenuevo)  
        {
            StringBuilder sb = new StringBuilder();

            

            sb.AppendLine("insert into cliente (Nombres, Apellidos, Email, Clave) ");
            sb.AppendLine("values(@Nombres, @Apellidos, @Email, md5(@Clave));") ;
            sb.AppendLine("SELECT LAST_INSERT_ID();") ;
            var sql = sb.ToString();

            using(var conn = CreateConnection()) { 
            
            var res =  await conn.QuerySingleAsync<int>(sql, new
            {
                @Nombres = clientenuevo.Nombres,
                @Apellidos = clientenuevo.Apellidos,
                @Email = clientenuevo.Email,
                @Clave = clientenuevo.Clave,
                
            });

                Cliente cliente = new Cliente();

                cliente.IdCliente = res;
                cliente.Nombres = clientenuevo.Nombres;
                cliente.Apellidos = clientenuevo.Apellidos;
                cliente.Email = clientenuevo.Email;
                cliente.Clave = clientenuevo.Clave;
               
                return cliente;
            }

           
        }

        public async Task<int> BorrarCliente(int id)
        {

            using(var conn = CreateConnection())
            {
              var sql = "delete  from cliente where IdCliente=@IdCliente";

              var res =  await conn.ExecuteAsync(sql, new { @IdCliente = id });

              return res;
           }
            
         }
           

        public async Task<Cliente> GetCliente(int id)
        {
            using (var conn = CreateConnection())
            {
                var sql = "select * from cliente where IdCliente=@IdCliente";

                
                var res  =  conn.QueryAsync<Cliente>(sql, new { @IdCliente = id });

              
                return (Cliente)await res;
            }
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            using (var connection = CreateConnection())
            {

                 var sql = "select * from cliente";

                 var clientes = connection.QueryAsync<Cliente>(sql);

                 return await clientes;

            }
                
        }

        public async Task<IEnumerable<Boleto>> GetBoletos()
        {
            using (var connection = CreateConnection())
            {

                var sql = "select * from boleto";

                var boletos = connection.QueryAsync<Boleto>(sql);

                return await boletos;

            }

        }

        public async Task<IEnumerable<Boleto>> GetBoletosCliente(int id)
        {
            using (var conn = CreateConnection())
            {
                var sql = "select * from boleto where IdCliente=@IdCliente";


                var boletos = conn.QueryAsync<Boleto>(sql, new { @IdCliente = id });


                return await boletos;
            }
        }

        public Task<IEnumerable<Premio>> GetPremios()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Premio>> GetPremiosCliente(int id)
        {
            throw new NotImplementedException();
        }
    }
}
