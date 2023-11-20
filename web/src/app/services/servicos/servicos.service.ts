import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { Servicos } from 'src/app/models/servicos';
import { LoginService } from 'src/app/@clientes/services/login/login.service';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ServicosService {
  _loginService: LoginService;

  constructor(
    private http: HttpClient,
    private loginService: LoginService,
  ) {
    this._loginService = loginService
  }

  private getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${this.loginService.jwt}`
    });
  }

  getServicos() {
    const url = urlJoin(environment.baseURL, 'servicos');

    return this.http.get<Servicos[]>(url, httpOptions);
  }

  getMyServices() {
    const url = urlJoin(environment.baseURL, 'servicos', 'myservices');

    const httpOptions = {
      headers: this.getHeaders()
    };

    return this.http.get<Servicos[]>(url, httpOptions);
  }

  add(nome: string, valor: number, id_categoria: number) {
    const url = urlJoin(environment.baseURL, 'servicos');

    const httpOptions = {
      headers: this.getHeaders()
    };

    return this.http.post(url, {
      nome,
      valor,
      id_categoria
    }, httpOptions);
  }
}
