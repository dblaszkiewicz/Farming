import { Injectable } from '@angular/core';
import { BehaviorSubject, lastValueFrom, Observable } from 'rxjs';
import { LandWithPlantDto } from '../models/land';
import { PesticideActionDto, PesticideStateDto } from '../models/pesticide';
import { PesticideWarehouseDto } from '../models/warehouse';
import { LandService } from '../services/land.service';
import { PesticideWarehouseService } from '../services/pesticide-warehouse.service';
import { PesticideService } from '../services/pesticide.service';
import { SpinnerStore } from './spinner.store';

@Injectable({
  providedIn: 'root',
})
export class PesticideActionService {
  private selectedLand: LandWithPlantDto | null;
  private selectedPesticide: PesticideStateDto | null;
  private selectedWarehouse: PesticideWarehouseDto | null;
  private selectedQuantity: number;

  private canGoToNextPanel: BehaviorSubject<boolean>;

  private lands: LandWithPlantDto[] = [];
  private pesticideStates: PesticideStateDto[] = [];
  private warehouses: PesticideWarehouseDto[] = [];

  constructor(
    private landService: LandService,
    private pesticideWarehouseService: PesticideWarehouseService,
    private pesticideService: PesticideService,
    private spinnerStore: SpinnerStore
  ) {
    this.canGoToNextPanel = new BehaviorSubject<boolean>(false);
  }

  public resetStore(): void {
    this.selectedLand = null;
    this.selectedPesticide = null;
    this.selectedWarehouse = null;
    this.lands = [];
    this.warehouses = [];
    this.pesticideStates = [];
    this.selectedQuantity = 0;
    this.canGoToNextPanel.next(false);
  }

  public canGoNext(): Observable<boolean> {
    return this.canGoToNextPanel.asObservable();
  }

  public getSelectedLand(): LandWithPlantDto | null {
    return this.selectedLand;
  }

  public getSelectedPesticide(): PesticideStateDto | null {
    return this.selectedPesticide;
  }

  public getSelectedWarehouse(): PesticideWarehouseDto | null {
    return this.selectedWarehouse;
  }

  public getSelectedQuantity(): number {
    return this.selectedQuantity;
  }

  public setSelectedQuantity(quantity: number): void {
    this.selectedQuantity = quantity;
  }

  public setSelectedLand(land: LandWithPlantDto | null): void {
    if (!land) {
      this.canGoToNextPanel.next(false);
    } else {
      this.canGoToNextPanel.next(true);
    }

    this.selectedLand = land;
    this.selectedPesticide = null;
    this.pesticideStates = [];
  }

  public setSelectedPesticide(pesticide: PesticideStateDto | null): void {
    if (!pesticide) {
      this.canGoToNextPanel.next(false);
    }

    this.selectedPesticide = pesticide;
  }

  public async setSelectedWarehouse(warehouse: PesticideWarehouseDto | null): Promise<void> {
    this.selectedWarehouse = warehouse;
    await this.preparePesticides();
  }

  public setCanGoNext(canGoNext: boolean): void {
    this.canGoToNextPanel.next(canGoNext);
  }

  public getLands(): LandWithPlantDto[] {
    return this.lands;
  }

  public getPesticideStates(): PesticideStateDto[] {
    return this.pesticideStates;
  }

  public getWarehouses(): PesticideWarehouseDto[] {
    return this.warehouses;
  }

  public async prepareLands(): Promise<void> {
    if (this.lands.length > 0) {
      return;
    }
    this.spinnerStore.startSpinner();
    this.lands = await lastValueFrom(this.landService.getAllWitPlant());
    this.spinnerStore.stopSpinner();
  }

  private async preparePesticides(): Promise<void> {
    this.spinnerStore.startSpinner();
    if (this.selectedLand?.isPlanted) {
      this.pesticideStates = await lastValueFrom(
        this.pesticideWarehouseService.getStatesByWarehouseAndPlantId(
          this.selectedWarehouse?.id!,
          this.selectedLand.planted.plantId
        )
      );
    } else {
      this.pesticideStates = await lastValueFrom(
        this.pesticideWarehouseService.getStatesByWarehouseId(this.selectedWarehouse?.id!)
      );
    }
    this.spinnerStore.stopSpinner();
  }

  public async prepareWarehouses(): Promise<void> {
    if (this.warehouses.length > 0) {
      return;
    }

    this.selectedWarehouse = null;

    this.spinnerStore.startSpinner();
    this.warehouses = await lastValueFrom(this.pesticideWarehouseService.getAll());
    this.spinnerStore.stopSpinner();
  }

  public async processAction(): Promise<void> {
    const actionDto: PesticideActionDto = {
      pesticideId: this.selectedPesticide?.pesticideId!,
      pesticideWarehouseId: this.selectedWarehouse?.id!,
      landId: this.selectedLand?.id!,
      quantity: this.selectedQuantity,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.pesticideService.processAction(actionDto));
    this.spinnerStore.stopSpinner();
  }
}
