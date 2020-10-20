using System;
using Entity;

namespace Controllers
{
    public class PersonaInputModel
    {
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public decimal Pulsacion { get; internal set; }
    }

    public class PersonaViewModel : PersonaInputModel
    {
        public PersonaViewModel(Persona persona)
        {
            Identificacion = persona.Identificacion;
            Nombre = persona.Nombre;
            Edad = persona.Edad;
            Sexo = persona.Sexo;
            Pulsacion = persona.Pulsacion;
        }
    }
}