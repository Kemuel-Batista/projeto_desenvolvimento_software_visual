/* eslint-disable @typescript-eslint/no-empty-function */
import { Injectable } from '@angular/core';
import { JwtPayload, jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  constructor() { }

  private validateJWT(jwt: string): boolean {
    const decodedJWT: JwtPayload = jwtDecode(jwt);

    if (decodedJWT.exp == null) return false;

    const expirationDate = new Date(0);
    expirationDate.setUTCSeconds(decodedJWT.exp);

    if (expirationDate < new Date()) return false;

    return true;
  }

  get jwt() {
    const jwt = sessionStorage.getItem('session');

    if (jwt != null && this.validateJWT(jwt)) {
      return jwt;
    } else {
      throw new Error('Invalid JWT');
    }
  }

  set jwt(jwt: string) {
    if (!this.validateJWT(jwt)) {
      throw new Error('Invalid JWT');
    }
    sessionStorage.setItem('session', jwt);
  }
}
