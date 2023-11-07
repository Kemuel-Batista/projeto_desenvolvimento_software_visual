import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { ClienteLoginResponse } from './interfaces/cliente-login-response';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const url = urlJoin(environment.baseURL, 'auth', 'cliente');

    console.log(url)

    return this.http.post<ClienteLoginResponse>(url, {
      email,
      password
    });
  }
}
