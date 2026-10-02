import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../../models/Cliente';
import { CrearCliente } from '../../models/CrearCliente';
import { UpdateCliente } from '../../models/UpdateCliente';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {

  private url ='https://localhost:7122/api/Cliente'

  constructor(private http:HttpClient) { }


  getCliente():Observable<Cliente[]>{
    return this.http.get<Cliente[]>(this.url);
  }

  postCliente(data:CrearCliente):Observable<CrearCliente>{
    return this.http.post<CrearCliente>(this.url,data);
  }

  updateCliente(id:number,data:UpdateCliente):Observable<UpdateCliente>{
    return this.http.put<UpdateCliente>(`${this.url}/${id}`,data);
  }
}
