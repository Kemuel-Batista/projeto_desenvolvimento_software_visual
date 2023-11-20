import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PrestadoresRoutingModule } from './prestadores-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { SignupComponent } from '../@clientes/components/signup/signup.component';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { PrestadoresComponent } from './components/prestadores/Cadastro/prestadores.component';
import { LoginComponent } from '../@prestadores/components/prestadores/Login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';



@NgModule({
  declarations: [
    PrestadoresComponent,
    LoginComponent,
    DashboardComponent,
    PedidosComponent
  ],
  imports: [
    CommonModule,
    PrestadoresRoutingModule,
    ReactiveFormsModule,
    SweetAlert2Module
  ]
})
export class PrestadoresModule { }
