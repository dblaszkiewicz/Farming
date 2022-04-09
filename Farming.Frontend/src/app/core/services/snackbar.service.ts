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
  private durationInMiliSeconds = 1500;

  constructor(private snackBar: MatSnackBar) {}

  public showFail(message: string) {
    this.openSnackBar(message, false);
  }

  public showSuccess(message: string) {
    this.openSnackBar(message, true);
  }

  private openSnackBar(message: string, success: boolean) {
    const config = new MatSnackBarConfig();

    config.horizontalPosition = this.horizontalPosition;
    config.verticalPosition = this.verticalPosition;
    config.duration = this.durationInMiliSeconds;
    config.panelClass = [success ? 'success-snackbar' : 'fail-snackbar', 'snackbar-alert'];

    this.snackBar.open(`${message}`, undefined, config);
  }
}
