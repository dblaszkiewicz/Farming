import { Injectable, Injector } from '@angular/core';
import {
  MatSnackBar,
  MatSnackBarHorizontalPosition,
  MatSnackBarVerticalPosition,
  MatSnackBarConfig,
} from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';
import { lastValueFrom } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  private horizontalPosition: MatSnackBarHorizontalPosition = 'right';
  private verticalPosition: MatSnackBarVerticalPosition = 'top';
  private durationInMiliSeconds = 3000;

  constructor(private snackBar: MatSnackBar, private readonly injector: Injector) {}

  public async showFail(message: string) {
    const translatedMessage = await this.translateMessage(message);
    this.openSnackBar(translatedMessage, 'fail-snackbar');
  }

  public async showFailValidationMessage(message: string) {
    const translatedMessage = await this.translateMessage(`ValidationMessageError.${message}`);
    this.openSnackBar(translatedMessage, 'fail-snackbar');
  }

  public async showFailErrorName(message: string) {
    const translatedMessage = await this.translateMessage(`Error.${message}`);
    this.openSnackBar(translatedMessage, 'fail-snackbar');
  }

  public async showSuccess(message: string) {
    const translatedMessage = await this.translateMessage(message);
    this.openSnackBar(translatedMessage, 'success-snackbar');
  }

  public async showInfo(message: string) {
    const translatedMessage = await this.translateMessage(message);
    this.openSnackBar(translatedMessage, 'info-snackbar');
  }

  private async translateMessage(message: string) {
    try {
      const translateService = this.injector.get(TranslateService);
      const result = await lastValueFrom(translateService.get(message));
      return result;
    } catch {
      return message;
    }
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
