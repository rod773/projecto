using Dapper;
using MySqlConnector;
using System.Data;
using WebApi.Models;
using WebApi.Servicios.Interfaces;

namespace WebApi.Servicios
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        private readonly string? _connectionString;

        private readonly IConfiguration _configuration;


        public IDbConnection CreateConnection() => new MySqlConnection(_connectionString);



        public ServicioAutenticacion(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("Default");

        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            using (var conn = CreateConnection())
            {
                var sql = "select email as correo,clave from cliente";


                var usuarios = conn.QueryAsync<Usuario>(sql);

               
                return await usuarios;
            }
        }
    }
}
