import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

import { LoginService } from '../../services/login/login.service';
import { ClientesService } from '../../services/clientes/clientes.service';
import { ClienteLoginResponse } from '../../services/clientes/interfaces/cliente-login-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm: any;
  tituloFormulario = '';

  constructor(
    private title: Title,
    private router: Router,
    private form: FormBuilder,
    private loginService: LoginService,
    private clientesService: ClientesService,
  ) {
    this.loginForm = this.form.group({
      email: new FormControl('', [Validators.required, Validators.nullValidator, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.nullValidator])
    });

    try {
      const jwt = this.loginService.jwt;
      if (jwt) {
        this.router.navigateByUrl('/clientes/dashboard');
      }
    } catch (error) { /* empty */ }

    this.title.setTitle('Login into your Personal Account')
  }

  sendLoginRequest() {
    const email = this.loginForm.get('email')?.value;
    const password = this.loginForm.get('password')?.value;

    if (!this.loginForm.valid || email == null || password == null) return;

    this.clientesService.login(email, password)
    .subscribe({
      next: (response: ClienteLoginResponse) => {
        this.loginService.jwt = response.token;
        this.router.navigateByUrl('/clientes/dashboard');
      },
      error: (error) => {
        if (error.status == 401) {
          alert('Invalid email or password');
        }
      }
    });
  }
}
