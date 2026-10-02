import { Component, OnInit } from '@angular/core';
import { ClienteService } from '../../../core/services/cliente.service';
import { Router } from '@angular/router';
import { Cliente } from '../../../models/Cliente';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-listarcliente',
  standalone: true,
  imports: [NgFor],
  templateUrl: './listarcliente.component.html',
  styleUrl: './listarcliente.component.css'
})
export class ListarclienteComponent implements OnInit{
  ngOnInit(): void {
    this.listar();
  }
cliente:Cliente[]=[];

  constructor(private clieteService:ClienteService,
              private router:Router
  ){}

  listar(){
    this.clieteService.getCliente().subscribe({
      next:(res:any)=>{
        this.cliente=res.data
        console.log('',res);
      },
      error:er=>console.log(er)
    });
  }

  editar(id:number){}

}
