using SoftCaribbean.Models;

namespace SoftCaribbean.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly SoftCaribbeanContext context;

        public PersonaService(SoftCaribbeanContext context)
        {
            this.context = context;
        }

        public bool ValidarSiExiste(Persona persona)
        {
            return context.Personas.Where(x => x.Documento.Equals(persona.Documento)).Count() > 0 ? true : false;
        }

        public int ObtenerIdParaActualizar(string documento)
        {
            return context.Personas.Where(x => x.Documento.Equals(documento)).Select(x => x.Id).FirstOrDefault();
        }

        public void ObtenerInformePacientesSp()
        {


        }
    }
}
