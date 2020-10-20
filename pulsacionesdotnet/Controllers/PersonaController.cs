using Microsoft.AspNetCore.Mvc;
using Logica;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Entity;
using Datos;

[Route("api/[controller]")]
[ApiController]
public class PersonaController : ControllerBase
{
    private readonly PersonaService _personaService;
    public IConfiguration Configuration { get; }
    public PersonaController(PulsacionesContext context)
    {
        _personaService = new PersonaService(context);
    }
    // GET: api/Persona​
    [HttpGet]
    public ActionResult<PersonaViewModel> Gets()
    {
        var response = _personaService.ConsultarTodos();
        if (response.Error)
        {
            return BadRequest(response.Mensaje);
        }
        else
        {
            return Ok(response.Personas.Select(p => new PersonaViewModel(p)));
        }
    }
    // GET: api/Persona/5​
    [HttpGet("{identificacion}")]
    public ActionResult<PersonaViewModel> Get(string identificacion)
    {
        var persona = _personaService.BuscarxIdentificacion(identificacion);
        if (persona == null) return NotFound();
        var personaViewModel = new PersonaViewModel(persona);
        return personaViewModel;
    }

    // POST: api/Persona​

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

    // DELETE: api/Persona/5​

    [HttpDelete("{identificacion}")]
    public ActionResult<string> Delete(string identificacion)
    {
        string mensaje = _personaService.Eliminar(identificacion);
        return Ok(mensaje);
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
}