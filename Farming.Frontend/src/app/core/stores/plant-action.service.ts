import { Injectable } from '@angular/core';
import { BehaviorSubject, lastValueFrom, Observable } from 'rxjs';
import { LandDto } from '../models/land';
import { PlantActionDto, PlantStateDto } from '../models/plant';
import { PlantWarehouseDto } from '../models/warehouse';
import { LandService } from '../services/farm-field.service';
import { PlantWarehouseService } from '../services/plant-warehouse.service';
import { PlantService } from '../services/plant.service';
import { SnackbarService } from '../services/snackbar.service';
import { SpinnerStore } from './spinner.store';

@Injectable({
  providedIn: 'root',
})
export class PlantActionService {
  private selectedLand: LandDto | null;
  private selectedPlant: PlantStateDto | null;
  private selectedWarehouse: PlantWarehouseDto | null;
  private selectedQuantity: number;

  private canGoToNextPanel: BehaviorSubject<boolean>;

  private lands: LandDto[] = [];
  private plantStates: PlantStateDto[] = [];
  private warehouses: PlantWarehouseDto[] = [];

  constructor(
    private landService: LandService,
    private plantWarehouseService: PlantWarehouseService,
    private plantService: PlantService,
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService
  ) {
    this.canGoToNextPanel = new BehaviorSubject<boolean>(false);
  }

  public resetStore(): void {
    this.selectedLand = null;
    this.selectedPlant = null;
    this.selectedWarehouse = null;
    this.lands = [];
    this.warehouses = [];
    this.plantStates = [];
    this.selectedQuantity = 0;
    this.canGoToNextPanel.next(false);
  }

  public canGoNext(): Observable<boolean> {
    return this.canGoToNextPanel.asObservable();
  }

  public getSelectedLand(): LandDto | null {
    return this.selectedLand;
  }

  public getSelectedPlant(): PlantStateDto | null {
    return this.selectedPlant;
  }

  public getSelectedWarehouse(): PlantWarehouseDto | null {
    return this.selectedWarehouse;
  }

  public getSelectedQuantity(): number {
    return this.selectedQuantity;
  }

  public setSelectedQuantity(quantity: number): void {
    this.selectedQuantity = quantity;
  }

  public setSelectedLand(land: LandDto | null): void {
    if (!land) {
      this.canGoToNextPanel.next(false);
    } else if (land.isPlanted) {
      this.canGoToNextPanel.next(false);
      this.snackbarService.showFail('Działka jest już zasiana');
    } else {
      this.canGoToNextPanel.next(true);
    }

    this.selectedLand = land;
    this.selectedPlant = null;
    this.plantStates = [];
  }

  public setSelectedPlant(plant: PlantStateDto | null): void {
    if (!plant) {
      this.canGoToNextPanel.next(false);
    }

    this.selectedPlant = plant;
  }

  public async setSelectedWarehouse(warehouse: PlantWarehouseDto | null): Promise<void> {
    this.selectedWarehouse = warehouse;
    await this.preparePlants();
  }

  public setCanGoNext(canGoNext: boolean): void {
    this.canGoToNextPanel.next(canGoNext);
  }

  public getLands(): LandDto[] {
    return this.lands;
  }

  public getPlantStates(): PlantStateDto[] {
    return this.plantStates;
  }

  public getWarehouses(): PlantWarehouseDto[] {
    return this.warehouses;
  }

  public async prepareLands(): Promise<void> {
    if (this.lands.length > 0) {
      return;
    }
    this.spinnerStore.startSpinner();
    this.lands = await lastValueFrom(this.landService.getAll());
    this.spinnerStore.stopSpinner();
  }

  private async preparePlants(): Promise<void> {
    this.spinnerStore.startSpinner();
    this.plantStates = await lastValueFrom(
      this.plantWarehouseService.getStatesByWarehouseId(this.selectedWarehouse?.id!)
    );
    this.spinnerStore.stopSpinner();
  }

  public async prepareWarehouses(): Promise<void> {
    if (this.warehouses.length > 0) {
      return;
    }

    this.selectedWarehouse = null;

    this.spinnerStore.startSpinner();
    this.warehouses = await lastValueFrom(this.plantWarehouseService.getAll());
    this.spinnerStore.stopSpinner();
  }

  public async processAction(): Promise<void> {
    const actionDto: PlantActionDto = {
      plantId: this.selectedPlant?.plantId!,
      plantWarehouseId: this.selectedWarehouse?.id!,
      landId: this.selectedLand?.id!,
      quantity: this.selectedQuantity,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.plantService.processAction(actionDto));
    this.spinnerStore.stopSpinner();
  }
}
