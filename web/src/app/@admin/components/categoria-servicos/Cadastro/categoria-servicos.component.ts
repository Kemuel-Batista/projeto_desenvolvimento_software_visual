import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { CategoriaServicosService } from '../../../services/categoria-servicos/categoria-servicos.service';
import { CategoriaServico } from '../../../models/categoria-servico';
import { Router } from '@angular/router';

@Component({
  selector: 'app-categoria-servicos',
  templateUrl: './categoria-servicos.component.html',
  styleUrls: ['./categoria-servicos.component.css']
})
export class CategoriaServicosComponent implements OnInit{
  formulario: any;
  tituloFormulario = '';

  constructor(
    private categoriaService : CategoriaServicosService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Categoria';
    this.formulario = new FormGroup({
      descricao: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const categoria : CategoriaServico = this.formulario.value;
    this.categoriaService.cadastrar(categoria).subscribe(result => {
      alert('Categoria cadastrada com sucesso.');
      this.router.navigateByUrl('/admin/listar');
    })
  }
}

