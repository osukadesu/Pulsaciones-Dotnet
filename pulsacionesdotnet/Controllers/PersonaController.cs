using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Entity;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    private readonly PersonaService _personaService;
    public IConfiguration Configuration { get; }
    public PersonaController(IConfiguration configuration)
    {
        Configuration = configuration;
        string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        _personaService = new PersonaService(connectionString);
    }
    // GET: api/Persona
    [HttpGet]
    public IEnumerable<PersonaViewModel> Gets()
    {
        var personas = _personaService.ConsultarTodos().Select(p => new PersonaViewModel(p));
        return personas;
    }
    // GET: api/Persona/5
    [HttpGet("{identificacion}")]
    public ActionResult<PersonaViewModel> Get(string identificacion)
    {
        var persona = _personaService.BuscarxIdentificacion(identificacion);
        if (persona == null) return NotFound();
        var personaViewModel = new PersonaViewModel(persona);
        return personaViewModel;
    }
    private Persona MapearPersona(PersonaInputModel personaInput)
    {
        var persona = new Persona
        {
            Identificacion = personaInput.Identificacion,
            Nombre = personaInput.Nombre,
            Edad = personaInput.Edad,
            Sexo = personaInput.Sexo,
            Pulsacion = personaInput.Pulsacion
        };
        
        return persona;
    }

    // POST: api/Persona
    [HttpPost]
    public ActionResult<PersonaViewModel> Post(PersonaInputModel personaInput)
    {
        Persona persona = MapearPersona(personaInput);
        var response = _personaService.Guardar(persona);
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        return Ok(response.Persona);
    }
    // DELETE: api/Persona/5
    [HttpDelete("{identificacion}")]
    public ActionResult<string> Delete(string identificacion)
    {
        string mensaje = _personaService.Eliminar(identificacion);
        return Ok(mensaje);
    }
}