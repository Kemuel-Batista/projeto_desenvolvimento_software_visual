import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ClientesService } from './services/clientes/clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';

import { ServicosService } from './services/servicos/servicos.service'
import { ServicosComponent } from './components/servicos/servicos.component';

import { PrestadoresService } from './services/prestadores/prestadores.service';
import { PrestadoresComponent } from './components/prestadores/prestadores.component';

import { PedidosService } from './services/pedidos/pedidos.service';
import { PedidosComponent } from './components/pedidos/pedidos.component';

import { CategoriaServicosService } from './services/categoria-servicos/categoria-servicos.service';
import { CategoriaServicosComponent } from './components/categoria-servicos/categoria-servicos.component';

import { AvaliacaoService } from './services/avaliacao/avaliacao.service';
import { AvaliacaoComponent } from './components/avaliacao/avaliacao.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    ServicosComponent,
    PrestadoresComponent,
    PedidosComponent,
    CategoriaServicosComponent,
    AvaliacaoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule
  ],
  providers: [HttpClientModule, ClientesService, ServicosService, PrestadoresService, PedidosService, CategoriaServicosService, AvaliacaoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
