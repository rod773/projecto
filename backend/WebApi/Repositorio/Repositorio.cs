using CrudDapper.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Data;
using System.Text;

namespace CrudDapper.Repositorio
{
    public class Repositorio : IRepositorio
    {
        

        private readonly string? _connectionString;

        private readonly IConfiguration _configuration;


        public Repositorio(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");
            
        }


        public IDbConnection CreateConnection()=>new MySqlConnection(_connectionString);
        






        public async Task ActualizarCliente(
            int IdCliente,
            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais,
            string FechaCreacion

            )
        {
            using(var  conn = CreateConnection()) { 
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("update cliente set Nombres=@Nombres,");
            sb.AppendLine("Apellidos=@Apellidos,");
            sb.AppendLine("Telefono=@Telefono,");
            sb.AppendLine("Email = @Email,");
            sb.AppendLine("Pais = @Pais,");
            sb.AppendLine("fechaCreacion = STR_TO_DATE(");
            sb.AppendLine("@FechaCreacion");
            sb.AppendLine(", '%Y-%m-%d')  ");
            sb.AppendLine("where idcliente = @IdCliente");

            var sql = sb.ToString ();

            var res = await conn.ExecuteAsync(
            sql, 
            new {
                @IdCliente = IdCliente,
                @Nombres = Nombres,
                @Apellidos = Apellidos,
                @Telefono = Telefono,
                @Email = Email,
                @Pais = Pais,
                @FechaCreacion = FechaCreacion,
            });


              
            
            }

            
        }

        public async Task<Cliente> AgregarCliente(

            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais

            )
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("insert into cliente (Nombres, Apellidos, Telefono, Email, Pais, fechaCreacion) ");
            sb.AppendLine("values(@Nombres, @Apellidos, @Telefono, @Email, @Pais, CURRENT_TIMESTAMP);") ;
            sb.AppendLine("SELECT LAST_INSERT_ID();") ;
            var sql = sb.ToString();

            using(var conn = CreateConnection()) { 
            
            var res =  await conn.QuerySingleAsync<int>(sql, new
            {
                @Nombres = Nombres,
                @Apellidos = Apellidos,
                @Telefono = Telefono,  
                @Email = Email,
                @Pais = Pais,
            });



                var cliente = new Cliente
                {
                    IdCliente = res,
                    Nombres = Nombres,
                    Apellidos = Apellidos,
                    Telefono= Telefono,
                    Email = Email,
                    Pais = Pais,
                    FechaCreacion= DateTime.Now,    
                };
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
    }
}
