import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
  HttpErrorResponse,
  HttpStatusCode,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs';
import { throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';
import { SpinnerStore } from '../stores/spinner.store';
import { AuthorizationService } from 'src/app/state/auth/authorization-service';
import { Store } from '@ngrx/store';
import { AuthState } from 'src/app/state/auth/auth.reducer';
import { AuthActions } from 'src/app/state/auth/auth.actions';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(
    private snackbarService: SnackbarService,
    private spinnerStore: SpinnerStore,
    private authorizationService: AuthorizationService,
    private store$: Store<{ auth: AuthState }>
  ) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authorizationService.rawToken;

    let observable = next.handle(request);

    if (token) {
      const bearerToken = `Bearer ${token}`;

      observable = next.handle(
        request.clone({
          setHeaders: {
            Authorization: bearerToken,
          },
        })
      );
    }

    return observable.pipe(
      catchError((error: HttpErrorResponse) => {
        this.spinnerStore.stopSpinner();

        if (error.status === 400) {
          this.snackbarService.showFailApi(error.error.message);
          return throwError(() => error.error.name);
        } else {
          if (error.status === HttpStatusCode.Unauthorized) {
            this.snackbarService.showFail('Sesja wygasła');
            this.store$.dispatch(AuthActions.logout());
          }
          return throwError(() => error.message);
        }
      })
    );
  }
}
