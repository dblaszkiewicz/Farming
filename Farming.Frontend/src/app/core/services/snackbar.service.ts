import { Injectable } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
  MatSnackBarConfig,
} from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  private horizontalPosition: MatSnackBarHorizontalPosition = 'right';
  private verticalPosition: MatSnackBarVerticalPosition = 'top';
  private durationInMiliSeconds = 3000;

  constructor(private snackBar: MatSnackBar) {}

  public showFail(message: string) {
    this.openSnackBar(message, 'fail-snackbar');
  }

  public showSuccess(message: string) {
    this.openSnackBar(message, 'success-snackbar');
  }

  public showInfo(message: string) {
    this.openSnackBar(message, 'info-snackbar');
  }

  private openSnackBar(message: string, mode: string) {
    const config = new MatSnackBarConfig();

    config.horizontalPosition = this.horizontalPosition;
    config.verticalPosition = this.verticalPosition;
    config.duration = this.durationInMiliSeconds;
    config.panelClass = [mode, 'snackbar-alert'];

    this.snackBar.open(`${message}`, undefined, config);
  }
}
