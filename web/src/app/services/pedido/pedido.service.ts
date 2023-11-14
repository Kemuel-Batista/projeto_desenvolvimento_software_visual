import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { LoginService } from 'src/app/@clientes/services/login/login.service';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {
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

  newOrder(idServico: number){
    const url = urlJoin(environment.baseURL, 'pedido');

    const httpOptions = {
      headers: this.getHeaders()
    };

    return this.http.post(url, {
      id_servico: idServico
    }, httpOptions);
  }
}
