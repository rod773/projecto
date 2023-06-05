using CrudDapper.Models;
using Dapper;
using MySqlConnector;
using System.Data;
using System.Text;

namespace CrudDapper.Repositorio
{
    public class Repositorio : IRepositorio
    {
        private readonly IDbConnection _bd;
        

        public Repositorio(string? conn)
        {
            _bd = new MySqlConnection(conn);
        }
        public Cliente ActualizarCliente(Cliente cliente)
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("update cliente set Nombres=@Nombres,");
            sb.AppendLine("Apellidos=@Apellidos,");
            sb.AppendLine("Telefono = 123456,");
            sb.AppendLine("Email = @Email,");
            sb.AppendLine("Pais = @Pais,");
            sb.AppendLine("fechaCreacion = @FechaCreacion,");
            sb.AppendLine("where idcliente = @IdCliente");

            var sql = sb.ToString ();

            _bd.Execute(sql,cliente);

            return cliente;
        }

        public Cliente AgregarCliente(Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("insert into cliente (Nombres, Apellidos, Telefono, Email, Pais, fechaCreacion) ");
            sb.AppendLine("values(@Nombres, @Apellidos, @Telefono, @Email, @Pais, CURRENT_TIMESTAMP);") ; 

            sb.AppendLine("SELECT LAST_INSERT_ID();");

            var sql = sb.ToString();

            var id = _bd.Query<int>(sql, new
            {
                @Nombres = cliente.Nombres,
                @Apellidos = cliente.Apellidos,
                @Telefono = cliente.Telefono,  
                @Email = cliente.Email,
                @Pais = cliente.Pais,
            }).Single();

            cliente.IdCliente = id;

            return cliente;
        }

        public void BorrarCliente(int id)
        {
            var sql = "delete * from cliente where IdCliente=@IdCliente";

            _bd.Execute(sql, new { @IdCliente = id });
        }

        public Cliente GetCliente(int id)
        {
            var sql = "select * from cliente where IdCliente=@IdCliente";

            return _bd.Query<Cliente>(sql,new { @IdCliente = id }).Single();
        }

        public List<Cliente> GetClientes()
        {
            var sql = "select * from cliente";

            return _bd.Query<Cliente>(sql).ToList();
        }
    }
}
