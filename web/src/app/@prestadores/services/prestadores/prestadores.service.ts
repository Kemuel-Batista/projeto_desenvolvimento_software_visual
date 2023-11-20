import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { PrestadoresLoginResponse } from '../../services/prestadores/interfaces/prestadores-login-response';
import { PrestadoresRegisterRequest } from '../../services/prestadores/interfaces/prestadores-register-request';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PrestadoresService {
  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const url = urlJoin(environment.baseURL, 'auth', 'prestador');

    return this.http.post<PrestadoresLoginResponse>(url, {
      email,
      password
    }, httpOptions);
  }

  register(data: PrestadoresRegisterRequest) {
    const url = urlJoin(environment.baseURL, 'prestador');

    return this.http.post<PrestadoresLoginResponse>(url, {
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
