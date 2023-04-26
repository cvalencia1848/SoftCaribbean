using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SoftCaribbean.DTOs;
using SoftCaribbean.Models;

namespace SoftCaribbean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly SoftCaribbeanContext context;
        private readonly IMapper mapper;

        public GenerosController(SoftCaribbeanContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("ObtenerTodos")]
        public Response<List<GeneroDTo>> ObtenerTodos()
        {
            var response = new Response<List<GeneroDTo>>();
            try
            {
                var generos = context.Generos.ToList();
                response.Entidad = mapper.Map<List<GeneroDTo>>(generos);
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
