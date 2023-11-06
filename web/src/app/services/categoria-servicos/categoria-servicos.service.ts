import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriaServico } from '../../models/categoria-servico';


const httpOptions = { 
  headers: new HttpHeaders({
  'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CategoriaServicosService {

  constructor(private http: HttpClient) { }
  cadastrar(categoria: CategoriaServico): Observable<any> {
  const apiUrl = 'http://localhost:5000/categoria';
  return this.http.post<CategoriaServico>(apiUrl, categoria, httpOptions);
  }
}
