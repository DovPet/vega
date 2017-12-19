import { CanActivate } from '@angular/router';
import { Auth } from './auth.service';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(protected auth: Auth) { }

  canActivate() { 
    if (this.auth.authenticated())
      return true;

    window.location.href = 'https://testavimui.eu.auth0.com/login?client=EuNStVm6TKSRwMsb0lvibL78xarIOEIh';
    return false;
  }
}