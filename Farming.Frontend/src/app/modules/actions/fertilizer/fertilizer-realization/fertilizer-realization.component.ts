import { ComponentRef, OnDestroy } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';
import { FertilizerActionSummaryComponent } from '../fertilizer-action-summary/fertilizer-action-summary.component';
import { SelectLandForFertilizerComponent } from '../select-land-for-fertilizer/select-land-for-fertilizer.component';
import { SelectFertilizerComponent } from '../select-fertilizer/select-fertilizer.component';
import { MatDialog } from '@angular/material/dialog';
import { lastValueFrom } from 'rxjs';
import { ChangeDetectorRef } from '@angular/core';
import { DynamicPanelDirective } from 'src/app/modules/shared/directives/dynamic-panel.directive';
import { ConfirmDialogComponent } from 'src/app/modules/shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-fertilizer-realization',
  templateUrl: './fertilizer-realization.component.html',
  styleUrls: ['./fertilizer-realization.component.scss'],
})
export class FertilizerRealizationComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild(DynamicPanelDirective) content!: DynamicPanelDirective;

  public canGoNextSubscription: Subscription;
  public canGoNext: boolean = false;
  public saveButton: boolean = false;
  private currentPanel: number = 1;
  private componentRef!: ComponentRef<RealizationComponentInterface>;

  constructor(
    private fertilizerActionService: FertilizerActionService,
    private snackbarService: SnackbarService,
    private router: Router,
    private dialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.setSubscription();
  }

  ngOnDestroy(): void {
    this.fertilizerActionService.resetStore();
    this.canGoNextSubscription.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.goToFields();
    this.cdr.detectChanges();
  }

  public goNext(): void {
    if (this.currentPanel === 1) {
      this.goToFertilizers();
      this.currentPanel++;
      this.saveButton = false;
    } else if (this.currentPanel === 2) {
      this.goToSummary();
      this.currentPanel++;
      this.saveButton = true;
    } else if (this.currentPanel === 3) {
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
    } else if (this.currentPanel === 3) {
      this.goToFertilizers();
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

    await this.fertilizerActionService.processAction();
    this.snackbarService.showSuccess('Dodano pomyślnie');
    this.router.navigateByUrl(`/`);
  }

  private goToFields(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectLandForFertilizerComponent);
  }

  private goToFertilizers(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectFertilizerComponent);
  }

  private goToSummary(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(FertilizerActionSummaryComponent);
  }

  private async goToMainPanel(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.router.navigateByUrl(`/`);
  }

  private setSubscription(): void {
    this.canGoNextSubscription = this.fertilizerActionService.canGoNext$().subscribe(value => {
      this.canGoNext = value;
    });
  }

  private async showConfirmDialog(): Promise<boolean> {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent);

    return await lastValueFrom(confirmDialog.afterClosed());
  }
}
