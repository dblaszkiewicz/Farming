import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { catchError, exhaustMap, map, tap } from 'rxjs/operators';
import { AuthActions } from './auth.actions';

import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/core/services/authentication.service';

@Injectable()
export class AuthEffects {
  constructor(
    private actions$: Actions,
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  logIn$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.login),
      exhaustMap(action =>
        this.authenticationService.logIn$(action.login, action.password).pipe(
          map(response => AuthActions.loginSuccess({ token: response.content.token })),
          tap(_ => {
            this.router.navigateByUrl('');
          }),
          catchError(_ => of(AuthActions.loginFailed()))
        )
      )
    )
  );

  logOut$ = createEffect(() =>
    this.actions$.pipe(
      ofType(AuthActions.logout),
      exhaustMap(action =>
        this.authenticationService.logOut$().pipe(
          map(_ => AuthActions.logoutSuccess()),
          tap(_ => {
            this.router.navigateByUrl('login');
          }),
          catchError(_ => of(AuthActions.logoutFailed()))
        )
      )
    )
  );
}
