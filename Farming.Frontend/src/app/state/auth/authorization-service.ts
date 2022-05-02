import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import jwtDecode from 'jwt-decode';
import { DecodedToken } from '../../core/models/basic';
import { AuthState } from './auth.reducer';
import { selectToken } from './auth.selectors';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  private _rawToken: string = '';
  private _decodedToken!: DecodedToken | null;

  public get rawToken(): string {
    return this._rawToken;
  }

  public get isAuthorized(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isAuthorized);
  }

  constructor(private store$: Store<{ auth: AuthState }>) {
    this.store$.select(selectToken).subscribe(token => {
      this._rawToken = token;

      if (!token) {
        this._decodedToken = null;
        return;
      }

      this._decodedToken = jwtDecode<DecodedToken>(token);
    });
  }

  public isAdmin(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isAdmin);
  }

  public isActive(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isActive);
  }

  public isActiveAdmin(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isActive) && /true/i.test(this._decodedToken.isAdmin);
  }

  public currentUserId(): string {
    if (!this._decodedToken) {
      return '';
    }

    return this._decodedToken.id;
  }

  public currentUserName(): string {
    if (!this._decodedToken) {
      return '';
    }

    return this._decodedToken.name;
  }
}
