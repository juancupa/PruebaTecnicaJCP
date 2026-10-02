import { Routes } from '@angular/router';

export const routes: Routes = [

  {path:'',redirectTo:'listarCliente',pathMatch:'full'},

  {path:'listarCliente',loadComponent:()=>import('./features/cliente/listarcliente/listarcliente.component')
    .then(p=>p.ListarclienteComponent)
  },
  {path:'cliente',loadComponent:()=>import('./features/cliente/crearcliente/crearcliente.component')
    .then(p=>p.CrearclienteComponent)
  }
];
