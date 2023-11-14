import { Component, OnInit } from '@angular/core';
import { ServicosService } from '../../../services/servicos/servicos.service';
import { Servicos } from 'src/app/models/servicos';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login/login.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  servicos: Servicos[] = []

  constructor(
    private _servicos: ServicosService,
    private _pedidos: PedidoService,
    private loginService: LoginService,
    private router: Router,
  ) {
    try {
      const jwt = this.loginService.jwt;
      if (jwt) {
        this.router.navigateByUrl('/clientes/dashboard');
      } else {
        this.router.navigateByUrl('/clientes');
      }
    } catch (error) { /* empty */ }
  }

  ngOnInit(): void {
    this.getServicos()
  }

  getServicos(): void {
    this._servicos.getServicos()
      .subscribe((res: Servicos[]) => {
        console.log('Result from getServicos: ', res);
        this.servicos = res;
      });
  }

  newOrder(idServico: number): void {
    this._pedidos.newOrder(idServico).subscribe()
  }
}
