import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/services/persona.service';
import { Persona } from '../models/persona';

@Component({
  selector: 'app-persona-registro',
  templateUrl: './persona-registro.component.html',
  styleUrls: ['./persona-registro.component.css']
})

export class PersonaRegistroComponent implements OnInit {
  persona: Persona;
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.persona = new Persona;
  }
  
  add() {
    alert('se agregó a una persona' + JSON.stringify(this.persona));
    this.personaService.post(this.persona).subscribe(p => {
      if (this.persona.edad <= 0 || this.persona.edad >= 101) {
        window.alert("Ingrese una edad validad");
      }
      else {
        if (p != null) {
          alert('Persona creada!');
          this.persona = p;
        }
        else
        {
          alert('Casillas vacias!');
        }
      }
    });
  }
}