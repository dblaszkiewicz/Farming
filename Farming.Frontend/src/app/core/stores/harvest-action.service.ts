import { Injectable } from '@angular/core';
import { BehaviorSubject, lastValueFrom, Observable } from 'rxjs';
import { LandWithPlantDto } from '../models/land';
import { LandStatusEnum } from '../models/static-types/land-status.enum';
import { LandService } from '../services/land.service';
import { SnackbarService } from '../services/snackbar.service';
import { SpinnerStore } from './spinner.store';

@Injectable({
  providedIn: 'root',
})
export class HarvestActionService {
  private selectedLand: LandWithPlantDto | null;
  private selectedNewLandStatus: LandStatusEnum | null;

  private canGoToNextPanel: BehaviorSubject<boolean>;

  private lands: LandWithPlantDto[] = [];

  constructor(
    private landService: LandService,
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService
  ) {
    this.canGoToNextPanel = new BehaviorSubject<boolean>(false);
  }

  public resetStore(): void {
    this.selectedLand = null;
    this.selectedNewLandStatus = null;
    this.lands = [];
    this.canGoToNextPanel.next(false);
  }

  public canGoNext$(): Observable<boolean> {
    return this.canGoToNextPanel.asObservable();
  }

  public getSelectedLand(): LandWithPlantDto | null {
    return this.selectedLand;
  }

  public setSelectedLand(land: LandWithPlantDto | null): void {
    if (!land) {
      this.canGoToNextPanel.next(false);
    }

    this.selectedLand = land;
  }

  public setSelectedNewLandStatus(status: LandStatusEnum | null): void {
    if (!status) {
      this.canGoToNextPanel.next(false);
    } else {
      this.canGoToNextPanel.next(true);
    }
    this.selectedNewLandStatus = status;
  }

  public setCanGoNext(canGoNext: boolean): void {
    this.canGoToNextPanel.next(canGoNext);
  }

  public getLands(): LandWithPlantDto[] {
    return this.lands;
  }

  public getSelectedLandStatus(): LandStatusEnum | null {
    return this.selectedNewLandStatus;
  }

  public async prepareLands(): Promise<void> {
    if (this.lands.length > 0) {
      return;
    }
    this.spinnerStore.startSpinner();
    this.lands = await lastValueFrom(this.landService.getAllWitPlant());
    this.spinnerStore.stopSpinner();
  }

  public async processAction(): Promise<void> {
    this.spinnerStore.startSpinner();
    if (this.selectedNewLandStatus == LandStatusEnum.Harvested) {
      await lastValueFrom(this.landService.harvest(this.selectedLand?.id!));
    } else if (this.selectedNewLandStatus == LandStatusEnum.Destroyed) {
      await lastValueFrom(this.landService.destroy(this.selectedLand?.id!));
    } else {
      this.snackbarService.showFail('BŁĄD');
    }
    this.spinnerStore.stopSpinner();
  }
}
