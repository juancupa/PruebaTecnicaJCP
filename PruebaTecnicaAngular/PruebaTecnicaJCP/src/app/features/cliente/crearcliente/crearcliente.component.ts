import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../../core/services/cliente.service';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TipoIdentificacion } from '../../../models/TipoIdentificacion';
import { TipoIdentificacionService } from '../../../core/services/tipo-identificacion.service';
import { Pais } from '../../../models/Pais';
import { Departamento } from '../../../models/Departamento';
import { Municipio } from '../../../models/Municipio';
import { UbicacionService } from '../../../core/services/ubicacion.service';
import { response } from 'express';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-crearcliente',
  standalone: true,
  imports: [ReactiveFormsModule,NgFor],
  templateUrl: './crearcliente.component.html',
  styleUrl: './crearcliente.component.css'
})
export class CrearclienteComponent implements OnInit {
  ngOnInit(): void {
    this.cargarPaises();
    this.getTipoDocumeneto();
  }


  constructor(private clienteService:ClienteService,
              private fb:FormBuilder,
              private router:Router,
              private route:ActivatedRoute,
              private tipoIdentificacionService:TipoIdentificacionService,
              private ubicacionService:UbicacionService
  ){}


    paises: Pais[] = [];
    departamentos: Departamento[] = [];
    municipios: Municipio[] = [];
    tipoDocumento:TipoIdentificacion[]=[];


  clienteForm = this.fb.nonNullable.group({
    clnTpoIdnId:[0,[Validators.required]],
    clnNumeroIdentificacion:['',[Validators.required]],
    clRazonSocial:['',[Validators.required]],
    paisCodigo:[null,[Validators.required]],
    departamentoCodigo:[null,[Validators.required]],
    clnDvsPltColCodigoDane:[0,[Validators.required]],
  });





  cargarPaises(): void {

    this.ubicacionService
      .getPais()
      .subscribe({
        next: (data) => {
          this.paises = data;
        },
        error: (error) => {
          console.error(
            'Error cargando países',
            error
          );
        }
      });
  }


  cambioPais():void{
      const paisCodigo= this.clienteForm.value.paisCodigo;

      this.departamentos=[];
      this.municipios=[];

      this.clienteForm.patchValue({
        departamentoCodigo:null,
        clnDvsPltColCodigoDane:0,
      });

      if(!paisCodigo){
        return;
      }

      this.ubicacionService.getDepartamento(paisCodigo).subscribe({
        next:(data)=>{
          this.departamentos=data;
        },
        error:(error)=>{
          console.error('Error cargando departamento', error);
        }
      });



  }

  cambioDepartamento():void{
    const departamentoCodigo= this.clienteForm.value.departamentoCodigo;

    this.municipios=[];

    this.clienteForm.patchValue({
      clnDvsPltColCodigoDane:0,
    });

    if(!departamentoCodigo){
      return;
    }

    this.ubicacionService.getMunicipio(departamentoCodigo)
                          .subscribe({
                            next:(data)=>{
                              this.municipios = data;
                            },
                              error: (error) => {
                                console.error(
                                  'Error cargando municipios',
                                  error
                                );
                              }
                          });
       }

guardar():void{
   if (this.clienteForm.invalid) {
    this.clienteForm.markAsTouched();
    return;
   }
   const cliente={
    clnTpoIdnId:this.clienteForm.value.clnTpoIdnId!,
    clnNumeroIdentificacion:this.clienteForm.value.clnNumeroIdentificacion!,
    clRazonSocial:this.clienteForm.value.clRazonSocial!,
    clnDvsPltColCodigoDane:this.clienteForm.value.clnDvsPltColCodigoDane!
   };

   this.clienteService.postCliente(cliente).subscribe({
      next:(response)=>{
         console.log('Cliente creado',response);

         this.clienteForm.reset();
         this.departamentos=[];
         this.municipios=[];
      },
        error: (error) => {
                console.error('Error creando cliente',error);
              }
   })
}



getTipoDocumeneto(){

 this.tipoIdentificacionService.getTipoIdentificacion().subscribe({
      next: (res: any) => {
        console.log('RESPUESTA API:', res);
        this.tipoDocumento = res.data;
      },
      error: er => {
        console.error('ERROR API:', er);
      }
    });
  }
}
