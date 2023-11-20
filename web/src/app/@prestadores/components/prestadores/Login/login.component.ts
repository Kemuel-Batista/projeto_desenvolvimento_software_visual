import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

import { LoginService } from '../../../services/prestadores/Login/login.service';
import { PrestadoresService } from '../../../services/prestadores/prestadores.service';
import { PrestadoresLoginResponse } from '../../../services/prestadores/interfaces/prestadores-login-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = this.form.group({
    email: new FormControl('', [Validators.required, Validators.nullValidator, Validators.email]),
    password: new FormControl('', [Validators.required, Validators.nullValidator])
  });

  constructor(
    private title: Title,
    private router: Router,
    private form: FormBuilder,
    private loginService: LoginService,
    private prestadoresService: PrestadoresService,
  ) {
    try {
      const jwt = this.loginService.jwt;
      if (jwt) {
        this.router.navigateByUrl('/prestadores/dashboard');
      }
    } catch (error) { /* empty */ }

    this.title.setTitle('Login into your Personal Account')
  }

  sendLoginRequest(event: Event) {
    event.preventDefault();

    const email = this.loginForm.get('email')?.value;
    const password = this.loginForm.get('password')?.value;

    if (!this.loginForm.valid || email == null || password == null) return;

    this.prestadoresService.login(email, password)
    .subscribe({
      next: (response: PrestadoresLoginResponse) => {
        this.loginService.jwt = response.token;
        this.router.navigateByUrl('/prestadores/dashboard');
      },
      error: (error) => {
        if (error.status == 400) {
          alert('Invalid email or password');
        }
      }
    });
  }
}
