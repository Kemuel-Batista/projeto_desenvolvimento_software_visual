import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formulario: any;
  tituloFormulario = '';

  ngOnInit(): void {
    this.tituloFormulario = 'Login';
    this.formulario = new FormGroup({

    })
  }

  submit(): void {

  }
}
