import { AfterViewInit, ComponentRef, ViewChild } from '@angular/core';
import { OnDestroy } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { lastValueFrom, Subscription } from 'rxjs';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { PesticideActionService } from 'src/app/core/stores/pesticide-action-service';
import { ConfirmDialogComponent } from 'src/app/modules/shared/confirm-dialog/confirm-dialog.component';
import { DynamicPanelDirective } from 'src/app/modules/shared/directives/dynamic-panel.directive';
import { PesticideActionSummaryComponent } from '../pesticide-action-summary/pesticide-action-summary.component';
import { SelectLandForPesticideComponent } from '../select-land-for-pesticide/select-land-for-pesticide.component';
import { SelectPesticideComponent } from '../select-pesticide/select-pesticide.component';

@Component({
  selector: 'app-pesticide-realization',
  templateUrl: './pesticide-realization.component.html',
  styleUrls: ['./pesticide-realization.component.scss'],
})
export class PesticideRealizationComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(DynamicPanelDirective) content!: DynamicPanelDirective;

  public canGoNextSubscription: Subscription;
  public canGoNext: boolean = false;
  public saveButton: boolean = false;
  private currentPanel: number = 1;
  private componentRef!: ComponentRef<RealizationComponentInterface>;

  constructor(
    private pesticideActionService: PesticideActionService,
    private snackbarService: SnackbarService,
    private router: Router,
    private dialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.setSubscription();
  }

  ngOnDestroy(): void {
    this.pesticideActionService.resetStore();
    this.canGoNextSubscription.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.goToFields();
    this.cdr.detectChanges();
  }

  public goNext(): void {
    if (this.currentPanel === 1) {
      this.goToPesticides();
      this.currentPanel++;
      this.saveButton = false;
    } else if (this.currentPanel === 2) {
      this.goToSummary();
      this.currentPanel++;
      this.saveButton = true;
    } else if (this.currentPanel === 3) {
      this.submitAction();
    } else {
      this.snackbarService.showFail('General.Error');
    }
  }

  public goBack(): void {
    if (this.currentPanel === 1) {
      this.goToMainPanel();
    } else if (this.currentPanel === 2) {
      this.goToFields();
      this.currentPanel--;
    } else if (this.currentPanel === 3) {
      this.goToPesticides();
      this.currentPanel--;
      this.saveButton = false;
    } else {
      this.snackbarService.showFail('General.Error');
    }
  }

  public async submitAction(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    await this.pesticideActionService.processAction();
    await this.snackbarService.showSuccess('PesticideRealization.Success');
    this.router.navigateByUrl(`/`);
  }

  private goToFields(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectLandForPesticideComponent);
  }

  private goToPesticides(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectPesticideComponent);
  }

  private goToSummary(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(PesticideActionSummaryComponent);
  }

  private async goToMainPanel(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.router.navigateByUrl(`/`);
  }

  private setSubscription(): void {
    this.canGoNextSubscription = this.pesticideActionService.canGoNext$().subscribe(value => {
      this.canGoNext = value;
    });
  }

  private async showConfirmDialog(): Promise<boolean> {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent);

    return await lastValueFrom(confirmDialog.afterClosed());
  }
}
