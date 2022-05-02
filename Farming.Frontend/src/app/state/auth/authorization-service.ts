import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import jwtDecode from 'jwt-decode';
import { Observable } from 'rxjs';
import { BehaviorSubject } from 'rxjs/internal/BehaviorSubject';
import { DecodedToken } from '../../core/models/basic';
import { AuthState } from './auth.reducer';
import { selectToken } from './auth.selectors';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  private _rawToken: string = '';
  private _decodedToken!: DecodedToken;

  private isAdminSubject: BehaviorSubject<boolean>;
  private isActiveSubject: BehaviorSubject<boolean>;
  private isAuthorizedSubject: BehaviorSubject<boolean>;

  constructor(private store$: Store<{ auth: AuthState }>) {
    this.isAdminSubject = new BehaviorSubject<boolean>(false);
    this.isActiveSubject = new BehaviorSubject<boolean>(false);
    this.isAuthorizedSubject = new BehaviorSubject<boolean>(false);

    this.store$.select(selectToken).subscribe(token => {
      this._rawToken = token;

      if (!token) {
        this.isAdminSubject.next(false);
        this.isActiveSubject.next(false);
        this.isAuthorizedSubject.next(false);
        return;
      }

      this._decodedToken = jwtDecode<DecodedToken>(token);

      this.isAdminSubject.next(/true/i.test(this._decodedToken.isAdmin));
      this.isActiveSubject.next(/true/i.test(this._decodedToken.isActive));
      this.isAuthorizedSubject.next(/true/i.test(this._decodedToken.isAuthorized));
    });
  }

  public get rawToken(): string {
    return this._rawToken;
  }

  public get authorized(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isAuthorized);
  }

  public get active(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isActive);
  }

  public get admin(): boolean {
    if (!this._decodedToken) {
      return false;
    }

    return /true/i.test(this._decodedToken.isAdmin);
  }

  public isAdmin$(): Observable<boolean> {
    return this.isAdminSubject.asObservable();
  }

  public isActive$(): Observable<boolean> {
    return this.isActiveSubject.asObservable();
  }

  public isAuthorized$(): Observable<boolean> {
    return this.isAuthorizedSubject.asObservable();
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
