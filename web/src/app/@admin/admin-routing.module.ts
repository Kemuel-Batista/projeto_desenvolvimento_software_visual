import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CategoriaServicosComponent } from './components/categoria-servicos/Cadastro/categoria-servicos.component';
import { ListarComponent } from './components/categoria-servicos/Listar/listar/listar.component';
import { EditarComponent } from './components/categoria-servicos/Editar/editar/editar.component';

const routes: Routes = [
  {path: 'cadastrar', component: CategoriaServicosComponent},
  {path: 'listar', component: ListarComponent},
  {path: 'listar/editar/:id', component: EditarComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
