import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { ClienteLoginResponse } from './interfaces/cliente-login-response';
import { ClienteRegisterRequest } from './interfaces/cliente-register-request';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const url = urlJoin(environment.baseURL, 'auth', 'cliente');

    return this.http.post<ClienteLoginResponse>(url, {
      email,
      password
    }, httpOptions);
  }

  register(data: ClienteRegisterRequest) {
    const url = urlJoin(environment.baseURL, 'clientes');

    return this.http.post<ClienteLoginResponse>(url, {
      nome: data.nome,
      cpf: data.cpf,
      email: data.email,
      telefone: data.telefone,
      password: data.password,
      cep: data.cep,
      endereco: data.endereco
    }, httpOptions);
  }
}
