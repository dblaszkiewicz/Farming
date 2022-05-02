import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable, of, tap } from 'rxjs';
import { AuthActions } from 'src/app/state/auth/auth.actions';
import { AuthState } from 'src/app/state/auth/auth.reducer';
import { AppSettings } from 'src/common/appsettings';
import { ApiResponse, TokenResponse } from '../models/basic';
import { LogInDto } from '../models/login';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationService {
  private readonly localStorageTokenKey = 'token';

  private get tokenEntryExistsInLocalStorage(): boolean {
    return !!this.tokenFromLocalStorage;
  }

  private get tokenFromLocalStorage(): string | null {
    return localStorage.getItem(this.localStorageTokenKey);
  }

  constructor(private store$: Store<{ auth: AuthState }>, private http: HttpClient) {
    if (this.tokenEntryExistsInLocalStorage) {
      this.store$.dispatch(AuthActions.loginSuccess({ token: this.tokenFromLocalStorage! }));
    }
  }

  public logIn$(login: string, password: string): Observable<ApiResponse<TokenResponse>> {
    const request: LogInDto = {
      login: login,
      password: password,
    };

    const url = `${AppSettings.authEndpoint}`;

    return this.http.post<ApiResponse<TokenResponse>>(url, request).pipe(
      tap(tokenResponse => {
        localStorage.setItem(this.localStorageTokenKey, tokenResponse.content.token);
      })
    );
  }

  public logOut$(): Observable<any> {
    localStorage.removeItem(this.localStorageTokenKey);

    return of('');
  }
}
