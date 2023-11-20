import { Component, OnInit, TemplateRef } from '@angular/core';
import { Servicos } from 'src/app/models/servicos';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { Router } from '@angular/router';
import { LoginService } from '../../../@prestadores/services/prestadores/Login/login.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CategoriaServico } from 'src/app/@admin/models/categoria-servico';
import { CategoriaServicosService } from 'src/app/@admin/services/categoria-servicos/categoria-servicos.service';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { ServicosService } from 'src/app/services/servicos/servicos.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  servicos: Servicos[] = []
  categoriaServicos: CategoriaServico[] = []
  modalRef?: BsModalRef;

  addServiceForm = this.form.group({
    nome: new FormControl('', [Validators.required, Validators.nullValidator]),
    valor: new FormControl(0, [Validators.required, Validators.nullValidator]),
    id_categoria: new FormControl(0, [Validators.required, Validators.nullValidator])
  });

  constructor(
    private _servicos: ServicosService,
    private _categoriaServicos: CategoriaServicosService,
    private _pedidos: PedidoService,
    private loginService: LoginService,
    private router: Router,
    private modalService: BsModalService,
    private form: FormBuilder,
  ) {
    try {
      const jwt = this.loginService.jwt;
      if (jwt) {
        this.router.navigateByUrl('/prestadores/dashboard');
      } else {
        this.router.navigateByUrl('/prestadores');
      }
    } catch (error) { /* empty */ }
  }

  ngOnInit(): void {
    this.getServicos()
    this.getCategoriasServicos()
  }

  getServicos(): void {
    this._servicos.getMyServices()
      .subscribe((res: Servicos[]) => {
        this.servicos = res;
      });
  }

  getCategoriasServicos(): void {
    this._categoriaServicos.listar().subscribe((res: CategoriaServico[]) => {
      this.categoriaServicos = res
    })
  }

  newOrder(idServico: number): void {
    this._pedidos.newOrder(idServico).subscribe()
  }

  openServicoModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  sendAddNewService(event: Event) {
    event.preventDefault();

    const nome = this.addServiceForm.get('nome')?.value;
    const valor = this.addServiceForm.get('valor')?.value;
    const id_categoria = this.addServiceForm.get('id_categoria')?.value;

    if (!this.addServiceForm.valid || nome == null || valor == null || id_categoria == null) return;

    this._servicos.add(nome, valor, id_categoria)
    .subscribe({
      next: () => {
        Swal.fire({
          title: 'Sucesso!',
          text: 'Serviço cadastrado com sucesso.',
          icon: 'success',
          confirmButtonText: 'Fechar',
        });

        this.modalRef?.hide();
        this.addServiceForm.reset();
        this.getServicos()
      },
      error: (error) => {
        if (error.status == 400) {
          Swal.fire({
            title: 'Erro!',
            text: 'Erro ao cadastrar o serviço.',
            icon: 'error',
            confirmButtonText: 'Fechar',
          });
        }
      }
    });
  }
}
