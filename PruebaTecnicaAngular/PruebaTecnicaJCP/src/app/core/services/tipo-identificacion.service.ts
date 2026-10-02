import { HttpClient } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { TipoIdentificacion } from '../../models/TipoIdentificacion';

@Injectable({
  providedIn: 'root'
})
export class TipoIdentificacionService implements OnInit{

  private url ='https://localhost:7122/api/TipoIdentificacion'

  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    this.getTipoIdentificacion();
  }

  getTipoIdentificacion(){
    return this.http.get<TipoIdentificacion[]>(this.url);
  }
}
