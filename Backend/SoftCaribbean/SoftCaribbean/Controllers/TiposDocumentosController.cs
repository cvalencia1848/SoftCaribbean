using Microsoft.AspNetCore.Mvc;
using SoftCaribbean.DTOs;
using SoftCaribbean.Models;

namespace SoftCaribbean.Controllers
{
    public class TiposDocumentosController : Controller
    {
        private readonly SoftCaribbeanContext context;

        public TiposDocumentosController(SoftCaribbeanContext context)
        {
            this.context = context;
        }
        [HttpGet("ObtenerTodos")]
        public Response<List<TiposDocumento>> ObtenerTodos()
        {
            var response = new Response<List<TiposDocumento>>();
            try
            {
                response.Entidad = context.TiposDocumentos.ToList();
                response.Exitoso = true;
                return response;
            }
            catch (Exception e)
            {
                response.MensajeError = e.Message;
                response.Exitoso = false;
                return response;
            }
        }
    }
}
