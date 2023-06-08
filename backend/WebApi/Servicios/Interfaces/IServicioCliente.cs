using WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace WebApi.Servicios.Interfaces
{
    public interface IServicioCliente
    {
        public Task<Cliente> GetCliente(int id);

        public Task<IEnumerable<Cliente>> GetClientes();

        public Task<Cliente> AgregarCliente(ClienteNuevo clientenuevo);

        public Task ActualizarCliente(Cliente cliente);

        public Task<int> BorrarCliente(int id);



    }
}
