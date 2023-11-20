import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { CategoriaServicosComponent } from './components/categoria-servicos/Cadastro/categoria-servicos.component';
import { ListarComponent } from './components/categoria-servicos/Listar/listar/listar.component';
import { EditarComponent } from './components/categoria-servicos/Editar/editar/editar.component';
import { ExcluirComponent } from './components/categoria-servicos/excluir/excluir.component'

@NgModule({
  declarations: [
    CategoriaServicosComponent,
    ListarComponent,
    EditarComponent,
    ExcluirComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class AdminModule { }
