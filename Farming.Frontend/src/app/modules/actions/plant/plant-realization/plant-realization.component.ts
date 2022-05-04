import { ChangeDetectorRef } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { Component, ComponentRef, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { lastValueFrom, Subscription } from 'rxjs';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { PlantActionService } from 'src/app/core/stores/plant-action.service';
import { ConfirmDialogComponent } from 'src/app/modules/shared/confirm-dialog/confirm-dialog.component';
import { DynamicPanelDirective } from 'src/app/modules/shared/directives/dynamic-panel.directive';
import { PlantActionSummaryComponent } from '../plant-action-summary/plant-action-summary.component';
import { SelectLandForPlantComponent } from '../select-land-for-plant/select-land-for-plant.component';
import { SelectPlantComponent } from '../select-plant/select-plant.component';

@Component({
  selector: 'app-plant-realization',
  templateUrl: './plant-realization.component.html',
  styleUrls: ['./plant-realization.component.scss'],
})
export class PlantRealizationComponent implements OnInit, AfterViewInit {
  @ViewChild(DynamicPanelDirective) content!: DynamicPanelDirective;

  public canGoNextSubscription: Subscription;
  public canGoNext: boolean = false;
  public saveButton: boolean = false;
  private currentPanel: number = 1;
  private componentRef!: ComponentRef<RealizationComponentInterface>;

  constructor(
    private plantActionService: PlantActionService,
    private snackbarService: SnackbarService,
    private router: Router,
    private dialog: MatDialog,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.setSubscription();
  }

  ngOnDestroy(): void {
    this.plantActionService.resetStore();
    this.canGoNextSubscription.unsubscribe();
  }

  ngAfterViewInit(): void {
    this.goToFields();
    this.cdr.detectChanges();
  }

  public goNext(): void {
    if (this.currentPanel === 1) {
      this.goToPlants();
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
      this.goToPlants();
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

    await this.plantActionService.processAction();
    this.snackbarService.showSuccess('Dodano pomyślnie');
    this.router.navigateByUrl(`/`);
  }

  private goToFields(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectLandForPlantComponent);
  }

  private goToPlants(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectPlantComponent);
  }

  private goToSummary(): void {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(PlantActionSummaryComponent);
  }

  private async goToMainPanel(): Promise<void> {
    if (!(await this.showConfirmDialog())) {
      return;
    }

    this.router.navigateByUrl(`/`);
  }

  private setSubscription(): void {
    this.canGoNextSubscription = this.plantActionService.canGoNext$().subscribe(value => {
      this.canGoNext = value;
    });
  }

  private async showConfirmDialog(): Promise<boolean> {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent);

    return await lastValueFrom(confirmDialog.afterClosed());
  }
}
