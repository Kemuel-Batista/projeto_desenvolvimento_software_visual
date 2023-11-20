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
  const apiUrl = 'https://localhost:7105/categoria';
  return this.http.post<CategoriaServico>(apiUrl, categoria, httpOptions);
  }
  listar(): Observable<any>{
    const apiUrl = 'https://localhost:7105/categoria';
    return this.http.get(apiUrl);
  }
  alterar(categoria: CategoriaServico): Observable<any> {
    const apiUrl = 'https://localhost:7105/categoria';
    return this.http.put<CategoriaServico>(apiUrl, categoria, httpOptions);
    }
  ListarId(id: string){
    
    return this.http.get<CategoriaServico>(`https://localhost:7105/categoria/${id}`);
  }
  EditarCategoria(id: number, categoria: CategoriaServico) : Observable<CategoriaServico>{
    return this.http.put<CategoriaServico>('https://localhost:7105/categoria/' + id, categoria);
  }
  ExcluirCategoria(id: number) : Observable<CategoriaServico>{
    return this.http.delete<CategoriaServico>('https://localhost:7105/categoria/' + id);
  }
}
