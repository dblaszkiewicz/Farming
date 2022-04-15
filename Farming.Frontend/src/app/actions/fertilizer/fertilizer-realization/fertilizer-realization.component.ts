import { ComponentRef, OnDestroy, ViewContainerRef } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';
import { DynamicPanelDirective } from 'src/app/shared/directives/dynamic-panel.directive';
import { FertilizerActionSummaryComponent } from '../fertilizer-action-summary/fertilizer-action-summary.component';
import { SelectFieldComponent } from '../../select-field/select-field.component';
import { SelectFertilizerComponent } from '../select-fertilizer/select-fertilizer.component';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/shared/confirm-dialog/confirm-dialog.component';
import { lastValueFrom } from 'rxjs';

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
    private dialog: MatDialog
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
  }

  goToFields() {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectFieldComponent);
  }

  goToFertilizers() {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(SelectFertilizerComponent);
  }

  goToSummary() {
    if (this.componentRef) {
      this.componentRef.destroy();
    }

    const viewContainerRef = this.content.viewContainerRef;
    viewContainerRef.clear();
    this.componentRef = viewContainerRef.createComponent(FertilizerActionSummaryComponent);
  }

  goNext() {
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

  goBack() {
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

  async submitAction() {
    const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
      width: '200px',
    });

    const result = await lastValueFrom(confirmDialog.afterClosed());

    if (!result) {
      return;
    }

    await this.fertilizerActionService.processAction();
    this.snackbarService.showSuccess('Dodano pomyślnie');
    this.router.navigateByUrl(`/`);
  }

  goToMainPanel() {
    this.router.navigateByUrl(`/`);
  }

  private setSubscription() {
    this.canGoNextSubscription = this.fertilizerActionService.canGoNext().subscribe(value => {
      this.canGoNext = value;
    });
  }
}
