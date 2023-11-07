import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servico } from 'src/app/prestadores/models/servico';

const httpOptions = {
  headers: new HttpHeaders({
  'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ServicosService {
  apiUrl = 'http://localhost:5000/servicos';
  constructor(private http: HttpClient) { }
  listar(): Observable<Servico[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Servico[]>(url);
  }
  buscar(placa: string): Observable<Servico> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Servico>(url);
  }
  cadastrar(servico: Servico): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Servico>(url, servico, httpOptions);
  }
  alterar(servico: Servico): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Servico>(url, servico, httpOptions);
  }
  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}

