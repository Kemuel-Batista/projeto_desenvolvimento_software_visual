import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './components/clientes/clientes.component';
import { AvaliacaoComponent } from './components/avaliacao/avaliacao.component';
import { CategoriaServicosComponent } from './components/categoria-servicos/categoria-servicos.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';

const routes: Routes = [
  {path: 'clientes', component: ClientesComponent},
  {path: 'avaliacao', component: AvaliacaoComponent},
  {path: 'categorias', component: CategoriaServicosComponent},
  {path: 'pedidos', component: PedidosComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
