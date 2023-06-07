using WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApi.Servicios.Interfaces
{
    public interface IServicioCliente
    {
        public Task<Cliente> GetCliente(int id);

        public Task<IEnumerable<Cliente>> GetClientes();

        public Task<Cliente> AgregarCliente(
            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais

            );

        public Task ActualizarCliente(
            int IdCliente,
            string Nombres,
            string Apellidos,
            int Telefono,
            string Email,
            string Pais,
            string FechaCreacion
            );

        public Task<int> BorrarCliente(int id);



    }
}
