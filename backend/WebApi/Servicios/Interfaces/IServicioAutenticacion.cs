using WebApi.Models;

namespace WebApi.Servicios.Interfaces
{
    public interface IServicioAutenticacion
    {
        public Task<IEnumerable<Usuario>> GetUsuarios();
    }
}
