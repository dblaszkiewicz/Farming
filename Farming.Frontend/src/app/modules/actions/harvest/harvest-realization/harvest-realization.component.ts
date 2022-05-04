import { ChangeDetectorRef } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { Component, ComponentRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { lastValueFrom, Subscription } from 'rxjs';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { HarvestActionService } from 'src/app/core/stores/harvest-action.service';
import { ConfirmDialogComponent } from 'src/app/modules/shared/confirm-dialog/confirm-dialog.component';
import { DynamicPanelDirective } from 'src/app/modules/shared/directives/dynamic-panel.directive';
import { HarvestActionSummaryComponent } from '../harvest-action-summary/harvest-action-summary.component';
import { SelectLandForHarvestComponent } from '../select-land-for-harvest/select-land-for-harvest.component';

@Component({
  selector: 'app-harvest-realization',
  templateUrl: './harvest-realization.component.html',
  styleUrls: ['./harvest-realization.component.scss'],
})
export class HarvestRealizationComponent implements OnInit, AfterViewInit {
  @ViewChild(DynamicPanelDirective) content!: DynamicPanelDirective;

  public canGoNextSubscription: Subscription;
  public canGoNext: boolean = false;
  public saveButton: boolean = false;
  private currentPanel: number = 1;
  private componentRef!: ComponentRef<RealizationComponentInterface>;

  constructor(
    private harvestActionService: HarvestActionService,
    private snackbarService: SnackbarService,
    private router: Router,
    private dialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.setSubscription();
  }

  ngOnDestroy(): void {
    this.harvestActionService.resetStore();
    this.canGoNextSubscription.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.goToFields();
    this.cdr.detectChanges();
  }

  public goNext(): void {
    if (this.currentPanel === 1) {
      this.goToSummary();
      this.currentPanel++;
      this.saveButton = true;
    } else if (this.currentPanel === 2) {
      this.submitAction();
    } else {
      this.snackbarService.showFail('BŁĄD');
    }
  }

  public goBack(): void {
    if (this.currentPanel === 1) {
      this.goToMainPanel();
    } else if (this.currentPanel === 2) {
      this.goToFields();
      this.currentPanel--;
      this.saveButton = false;
    } else {
      this.snackbarService.showFail('BŁĄD');
    }
  }

  public async submitAction(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    await this.harvestActionService.processAction();
    this.snackbarService.showSuccess('Dodano pomyślnie');
    this.router.navigateByUrl(`/`);
  }

  private goToFields(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectLandForHarvestComponent);
  }

  private goToSummary(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(HarvestActionSummaryComponent);
  }

  private async goToMainPanel(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.router.navigateByUrl(`/`);
  }

  private setSubscription(): void {
    this.canGoNextSubscription = this.harvestActionService.canGoNext$().subscribe(value => {
      this.canGoNext = value;
    });
  }

  private async showConfirmDialog(): Promise<boolean> {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent);

    return await lastValueFrom(confirmDialog.afterClosed());
  }
}
