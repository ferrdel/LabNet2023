import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Categoria } from '../models/categoria';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {

  endpoint: string = 'Categories';

  constructor(private http: HttpClient) { }

  public crearCategoria(categoriaRequest: Categoria): Observable<any> {
    let url = environment.apiCategorias + this.endpoint;
    return this.http.post(url, categoriaRequest);
  }

  public listarCategoria(): Observable<any> {
    let url = environment.apiCategorias + this.endpoint;
    return this.http.get(url);
  }

  public eliminarCategoria(id: number): Observable<any> {
    let url = environment.apiCategorias + this.endpoint;
    return this.http.delete(url + "/" + id);
  }

  public modificarCategoria(id: number, categoria: Categoria): Observable<any> {
    let url = environment.apiCategorias + this.endpoint;
    return this.http.put<any>(url + "/" + id, categoria);
  }

}
