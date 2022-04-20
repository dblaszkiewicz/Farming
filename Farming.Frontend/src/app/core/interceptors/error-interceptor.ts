import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpErrorResponse } from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { catchError } from 'rxjs';
import { throwError } from 'rxjs';
import { SnackbarService } from '../services/snackbar.service';
import { SpinnerStore } from '../stores/spinner.store';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private snackbarService: SnackbarService, private spinnerStore: SpinnerStore) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        this.spinnerStore.stopSpinner();
        if (error.status === 400) {
          this.snackbarService.showFail(error.error.message);
          return throwError(() => error.error.name);
        } else {
          return throwError(() => error.message);
        }
      })
    );
  }
}
