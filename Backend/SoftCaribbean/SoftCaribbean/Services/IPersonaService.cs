using SoftCaribbean.Models;

namespace SoftCaribbean.Services
{
    public interface IPersonaService
    {
        bool ValidarSiExiste(Persona persona);

        int ObtenerIdParaActualizar(string documento);
    }
}
