import { Component } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { ClientesService } from '../../services/clientes/clientes.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  registerForm = this.form.group({
    nome: new FormControl('', [Validators.required, Validators.nullValidator]),
    cpf: new FormControl('', [Validators.required, Validators.nullValidator]),
    email: new FormControl('', [Validators.required, Validators.nullValidator, Validators.email]),
    telefone: new FormControl('', [Validators.required, Validators.nullValidator]),
    password: new FormControl('', [Validators.required, Validators.nullValidator]),
    cep: new FormControl('', [Validators.required, Validators.nullValidator]),
    endereco: new FormControl('', [Validators.required, Validators.nullValidator]),
  });

  constructor(
    private title: Title,
    private form: FormBuilder,
    private router: Router,
    private clientesService: ClientesService,
  ) {
    this.title.setTitle('Register your Account');
  }

  sendRegisterAccountRequest(event: Event) {
    event.preventDefault();

    const nome = this.registerForm.get('nome')?.value;
    const cpf = this.registerForm.get('cpf')?.value;
    const email = this.registerForm.get('email')?.value;
    const telefone = this.registerForm.get('telefone')?.value;
    const password = this.registerForm.get('password')?.value;
    const cep = this.registerForm.get('cep')?.value;
    const endereco = this.registerForm.get('endereco')?.value;

    if (!this.registerForm.valid || nome == null || cpf == null || email == null || telefone == null || password == null || cep == null || endereco == null) return;

    const clienteRegisterData = {
      nome,
      cpf,
      email,
      telefone,
      password,
      cep,
      endereco
    }

    this.clientesService.register(clienteRegisterData)
    .subscribe({
      next: () => {
        alert('Sucesso ao cadastrar sua conta!');
        this.router.navigateByUrl('/clientes');
      },
      error: (error) => {
        if (error.status == 400) {
          alert('Erro ao cadastrar sua conta!');
        }
      }
    });
  }
}
