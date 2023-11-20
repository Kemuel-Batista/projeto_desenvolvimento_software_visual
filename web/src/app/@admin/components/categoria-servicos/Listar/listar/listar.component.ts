import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoriaServicosService } from '../../../../services/categoria-servicos/categoria-servicos.service';
import { CategoriaServico } from '../../../../models/categoria-servico';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-listar',
  templateUrl: './listar.component.html',
  styleUrls: ['./listar.component.css']
})

export class ListarComponent implements OnInit{

  categorias: any;

  constructor(private categoriaService : CategoriaServicosService) { }
  ngOnInit(): void{
    this.Listar();
  }
  Listar(){
    this.categoriaService.listar().subscribe(data=>{
      console.log('categorias',data);
      this.categorias = data;
    })
  }


}
