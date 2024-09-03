import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, Injectable, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Observable } from 'rxjs';
import { Contactos } from '../models/contacto.model';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  http = inject(HttpClient);

  contactosForm = new FormGroup({
    nombre: new FormControl<string>(''),
    apellido: new FormControl<string>(''),
    email: new FormControl<string>(''),
    comentario: new FormControl<string>('')
  })

  contactos$ = this.getContactos();

  onFormSubmit(){
    //console.log(this.contactosForm.value);
    const addContactosRequest={
      Nombre:this.contactosForm.value.nombre,
      Apellido:this.contactosForm.value.apellido,
      Email:this.contactosForm.value.email,
      comentario:this.contactosForm.value.comentario
    }

    this.http.post('https://localhost:7026/api/Contactos', addContactosRequest)
    .subscribe({
      next:(value)=>{
        console.log(value);
        this.contactos$ = this.getContactos();
        this.contactosForm.reset();
      }
    })
  }

  onDelete(id: string) {
    this.http.delete(`https://localhost:7026/api/Contactos/${id}`)
    .subscribe({
      next:(value)=>{
        alert("Comentario eliminado")
        this.contactos$ = this.getContactos();
      }
  })
}
  private getContactos(): Observable<Contactos[]>{
    return this.http.get<Contactos[]>('https://localhost:7026/api/Contactos');
  }
}

