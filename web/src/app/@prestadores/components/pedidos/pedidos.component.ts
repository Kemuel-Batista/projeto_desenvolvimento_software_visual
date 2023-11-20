import { Component, OnInit } from '@angular/core';
import { Pedidos } from 'src/app/models/pedidos';
import { PedidoService } from 'src/app/services/pedido/pedido.service';
import { LoginService } from '../../../@clientes/services/login/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  pedidos: Pedidos[] = []

  constructor(
    private _pedidos: PedidoService,
    private loginService: LoginService,
    private router: Router,
  ) {
    try {
      const jwt = this.loginService.jwt;
      if (jwt) {
        this.router.navigateByUrl('/prestadores/pedidos');
      } else {
        this.router.navigateByUrl('/prestadores');
      }
    } catch (error) { /* empty */ }
  }


  ngOnInit(): void {
    this.getPedidos()
  }

  getPedidos(): void {
    this._pedidos.getPedidos()
      .subscribe((res: Pedidos[]) => {
        console.log('Result from getPedidos: ', res);
        this.pedidos = res;
      });
  }
}
