import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';
import { Pais } from '../../models/Pais';
import { HttpClient } from '@angular/common/http';
import { Departamento } from '../../models/Departamento';
import { Municipio } from '../../models/Municipio';

@Injectable({
  providedIn: 'root'
})
export class UbicacionService implements OnInit{

 private url = 'https://localhost:7122/api/Ubicacion';

  constructor(private http:HttpClient) { }
  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }


  getPais():Observable<Pais[]>{
    return this.http.get<Pais[]>(`${this.url}/paises`);
  }

  getDepartamento(paisCodigo:number):Observable<Departamento[]>{
    return this.http.get<Departamento[]>( `${this.url}/departamentos/${paisCodigo}`);
  }

  getMunicipio(departamentoCodigo:number):Observable<Municipio[]>{
    return this.http.get<Municipio[]>( `${this.url}/municipios/${departamentoCodigo}`);
  }
}
