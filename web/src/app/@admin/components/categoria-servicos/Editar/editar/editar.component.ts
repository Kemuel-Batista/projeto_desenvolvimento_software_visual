import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoriaServicosService } from '../../../../services/categoria-servicos/categoria-servicos.service';
import { CategoriaServico } from '../../../../models/categoria-servico';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {

  formulario: any;
  categorias: CategoriaServico = {
    id: 0,
    descricao: ''
  };
 
  constructor(private categoriaService : CategoriaServicosService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    this.formulario = new FormGroup({
    descricao: new FormControl(null)
    })
    this.route.paramMap.subscribe({
      next: (params) =>{
        const id = params.get('id');
       
        if(id)
        {
          this.categoriaService.ListarId(id).subscribe((result)=>{
            //console.log(result);
            this.categorias = result;
           // console.log(this.categorias.id);
            //console.log(this.categorias.descricao);

          });
        }
        
      }
    })
    
  }

  EditarCategoria(){

    console.log('uiouioio' + this.categorias.id);

    this.categoriaService.EditarCategoria(this.categorias.id, this.categorias).subscribe({
      next: (result) => {
        console.log('Categoria editada com sucesso');
      }
    });
  }

  ExcluirCategoria(id: number){
    this.categoriaService.ExcluirCategoria(id).subscribe({
      next: (result) =>{
        alert('Categoria excluída com sucesso');
      }
    })
  }
  

}
