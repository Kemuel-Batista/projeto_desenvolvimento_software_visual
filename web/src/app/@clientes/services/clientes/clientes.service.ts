import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { ClienteLoginResponse } from './interfaces/cliente-login-response';

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
}
