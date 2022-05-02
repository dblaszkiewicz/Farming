import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { ProgressSpinnerComponent } from 'src/app/modules/shared/progress-spinner/progress-spinner.component';

@Injectable({
  providedIn: 'root',
})
export class SpinnerStore {
  public dialogRef: MatDialogRef<ProgressSpinnerComponent>;

  private isVisible = false;

  constructor(private dialog: MatDialog) {}

  public startSpinner() {
    if (!this.isVisible) {
      this.isVisible = true;
      this.start();
    }
  }

  public stopSpinner() {
    if (this.isVisible) {
      this.isVisible = false;
      this.stop();
    }
  }

  private start() {
    this.dialogRef = this.dialog.open(ProgressSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true,
    });
  }

  private stop() {
    this.dialogRef.close();
  }
}
