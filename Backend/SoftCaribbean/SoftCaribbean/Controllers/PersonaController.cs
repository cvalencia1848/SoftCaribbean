using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftCaribbean.DTOs;
using SoftCaribbean.Models;
using SoftCaribbean.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoftCaribbean.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly SoftCaribbeanContext context;
        private readonly IMapper mapper;
        private readonly IPersonaService personaServicio;

        public PersonaController(SoftCaribbeanContext context, IMapper mapper, IPersonaService personaServicio)
        {
            this.context = context;
            this.mapper = mapper;
            this.personaServicio = personaServicio;
        }

        // GET api/<PersonaController>/5
        [HttpGet("ObtenerPorId/{id}")]
        public async Task<Response<PersonaDTo>> ObtenerPorId(int id)
        {
            var response = new Response<PersonaDTo>();
            try
            {
                var persona = await context.Personas.Where(x => x.Id == id).FirstOrDefaultAsync();
                response.Entidad = mapper.Map<PersonaDTo>(persona);
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

        [HttpGet("ObtenerTodos")]
        public Response<List<PersonaDTo>> ObtenerTodos()
        {
            var response = new Response<List<PersonaDTo>>();
            try
            {
                var personas = context.Personas.ToList();
                response.Entidad = mapper.Map<List<PersonaDTo>>(personas);
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

        // POST api/<PersonaController>
        [HttpPost("ActualizarOGuardar")]
        public Response<PersonaDTo> ActualizarOGuardar(PersonaDTo personaDto)
        {
            var response = new Response<PersonaDTo>();
            try
            {
                var persona = mapper.Map<Persona>(personaDto);
                if (personaServicio.ValidarSiExiste(persona))
                {
                    persona.Id = personaServicio.ObtenerIdParaActualizar(persona.Documento);
                    context.Update(persona);
                }
                else
                {
                    context.Add(persona);
                }
                context.SaveChanges();
                response.Entidad = personaDto;
                response.Exitoso = true;
                return response;
            }
            catch (Exception e)
            {
                response.Exitoso = false;
                response.MensajeError = e.Message;
                return response;
            }
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("Eliminar/{id}")]
        public Response<Persona> Eliminar(int id)
        {
            var response = new Response<Persona>();
            try
            {
                var personaEliminar = new Persona() { Id = id };
                context.Personas.Attach(personaEliminar);
                context.Remove(personaEliminar);
                context.SaveChanges();
                response.Entidad = personaEliminar;
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

        [HttpGet("ObtenerTodosInforme")]
        public Response<List<PersonaDTo>> ObtenerTodosInforme()
        {
            var response = new Response<List<PersonaDTo>>();
            try
            {
                var personas = context.Personas.ToList();
                response.Entidad = mapper.Map<List<PersonaDTo>>(personas);
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
