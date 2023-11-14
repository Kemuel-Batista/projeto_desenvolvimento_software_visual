import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import urlJoin from 'url-join';
import { environment } from 'src/environments/environment.development';
import { Servicos } from 'src/app/models/servicos';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ServicosService {
  constructor(private http: HttpClient) { }

  getServicos() {
    const url = urlJoin(environment.baseURL, 'servicos');

    return this.http.get<Servicos[]>(url, httpOptions);
  }
}
