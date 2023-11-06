import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Avaliacao } from '../../models/avaliacao';

const httpOptions = {
  headers: new HttpHeaders({
  'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class AvaliacaoService {
  apiUrl = 'http://localhost:5000/avaliacao';
  constructor(private http: HttpClient) { }
  listar(): Observable<Avaliacao[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Avaliacao[]>(url);
  }
  buscar(placa: string): Observable<Avaliacao> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Avaliacao>(url);
  }
  cadastrar(avaliacao: Avaliacao): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Avaliacao>(url, avaliacao, httpOptions);
  }
  alterar(avaliacao: Avaliacao): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Avaliacao>(url, avaliacao, httpOptions);
  }
  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
