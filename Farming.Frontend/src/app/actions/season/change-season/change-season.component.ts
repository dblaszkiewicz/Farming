import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { SeasonDto } from 'src/app/core/models/season';
import { SeasonService } from 'src/app/core/services/season.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';
import { ConfirmDialogComponent } from 'src/app/shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-change-season',
  templateUrl: './change-season.component.html',
  styleUrls: ['./change-season.component.scss'],
})
export class ChangeSeasonComponent implements OnInit {
  public currentSeason: SeasonDto | null;

  constructor(
    private seasonService: SeasonService,
    private dialog: MatDialog,
    private router: Router,
    private spinnerStore: SpinnerStore
  ) {}

  async ngOnInit(): Promise<void> {
    await this.initData();
  }

  private async initData() {
    this.spinnerStore.startSpinner();
    this.currentSeason = await lastValueFrom(this.seasonService.getCurrent());
    this.spinnerStore.stopSpinner();
  }

  public async endCurrentSeason() {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.seasonService.endCurrent());
    this.spinnerStore.stopSpinner();

    await this.initData();
  }

  public async startNewSeason() {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.seasonService.startNew());
    this.spinnerStore.stopSpinner();

    await this.initData();
  }

  public async goToMainPanel(): Promise<void> {
    this.router.navigateByUrl(`/`);
  }

  private async showConfirmDialog(): Promise<boolean> {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
      width: '200px',
    });

    return await lastValueFrom(confirmDialog.afterClosed());
  }
}
