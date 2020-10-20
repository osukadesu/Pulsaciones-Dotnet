import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'personaRegistro', component: PersonaRegistroComponent },
  { path: 'personaConsulta', component: PersonaConsultaComponent },
  { path: '', component: HomeComponent }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})

export class AppRoutingModule { }