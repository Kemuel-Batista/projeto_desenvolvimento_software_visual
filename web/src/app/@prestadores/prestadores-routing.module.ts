import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PrestadoresComponent } from '../../app/@prestadores/components/prestadores/Cadastro/prestadores.component';
import { LoginComponent } from '../../app/@prestadores/components/prestadores/Login/login.component';
import { DashboardComponent } from '../../app/@prestadores/components/dashboard/dashboard.component';
import { PedidosComponent } from '../../app/@prestadores/components/pedidos/pedidos.component';


const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'cadastrar', component: PrestadoresComponent },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'pedidos', component: PedidosComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PrestadoresRoutingModule { }
