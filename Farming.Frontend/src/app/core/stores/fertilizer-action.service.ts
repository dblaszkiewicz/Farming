import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, lastValueFrom } from 'rxjs';
import { FertilizerActionDto, FertilizerStateDto } from '../models/fertilizer';
import { LandWithPlantDto } from '../models/land';
import { LandService } from '../services/land.service';
import {} from 'rxjs';
import { FertilizerWarehouseDto } from '../models/warehouse';
import { FertilizerWarehouseService } from '../services/fertilizer-warehouse.service';
import { FertilizerService } from '../services/fertilizer.service';
import { SpinnerStore } from './spinner.store';

@Injectable({
  providedIn: 'root',
})
export class FertilizerActionService {
  private selectedLand: LandWithPlantDto | null;
  private selectedFertilizer: FertilizerStateDto | null;
  private selectedWarehouse: FertilizerWarehouseDto | null;
  private selectedQuantity: number;

  private canGoToNextPanel: BehaviorSubject<boolean>;

  private lands: LandWithPlantDto[] = [];
  private fertilizerStates: FertilizerStateDto[] = [];
  private warehouses: FertilizerWarehouseDto[] = [];

  constructor(
    private landService: LandService,
    private fertilizerWarehouseService: FertilizerWarehouseService,
    private fertilizerService: FertilizerService,
    private spinnerStore: SpinnerStore
  ) {
    this.canGoToNextPanel = new BehaviorSubject<boolean>(false);
  }

  public resetStore(): void {
    this.selectedLand = null;
    this.selectedFertilizer = null;
    this.selectedWarehouse = null;
    this.lands = [];
    this.warehouses = [];
    this.fertilizerStates = [];
    this.selectedQuantity = 0;
    this.canGoToNextPanel.next(false);
  }

  public canGoNext$(): Observable<boolean> {
    return this.canGoToNextPanel.asObservable();
  }

  public getSelectedLand(): LandWithPlantDto | null {
    return this.selectedLand;
  }

  public getSelectedFertilizer(): FertilizerStateDto | null {
    return this.selectedFertilizer;
  }

  public getSelectedWarehouse(): FertilizerWarehouseDto | null {
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
    this.selectedFertilizer = null;
    this.fertilizerStates = [];
  }

  public setSelectedFertilizer(fertilizer: FertilizerStateDto | null): void {
    if (!fertilizer) {
      this.canGoToNextPanel.next(false);
    }

    this.selectedFertilizer = fertilizer;
  }

  public async setSelectedWarehouse(warehouse: FertilizerWarehouseDto | null): Promise<void> {
    this.selectedWarehouse = warehouse;
    await this.prepareFertilziers();
  }

  public setCanGoNext(canGoNext: boolean): void {
    this.canGoToNextPanel.next(canGoNext);
  }

  public getLands(): LandWithPlantDto[] {
    return this.lands;
  }

  public getFertilizerStates(): FertilizerStateDto[] {
    return this.fertilizerStates;
  }

  public getWarehouses(): FertilizerWarehouseDto[] {
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

  private async prepareFertilziers(): Promise<void> {
    this.spinnerStore.startSpinner();
    if (this.selectedLand?.isPlanted) {
      this.fertilizerStates = await lastValueFrom(
        this.fertilizerWarehouseService.getStatesByWarehouseAndPlantId(
          this.selectedWarehouse?.id!,
          this.selectedLand.planted.plantId
        )
      );
    } else {
      this.fertilizerStates = await lastValueFrom(
        this.fertilizerWarehouseService.getStatesByWarehouseId(this.selectedWarehouse?.id!)
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
    this.warehouses = await lastValueFrom(this.fertilizerWarehouseService.getAll());
    this.spinnerStore.stopSpinner();
  }

  public async processAction(): Promise<void> {
    const actionDto: FertilizerActionDto = {
      fertilizerId: this.selectedFertilizer?.fertilizerId!,
      fertilizerWarehouseId: this.selectedWarehouse?.id!,
      landId: this.selectedLand?.id!,
      quantity: this.selectedQuantity,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.fertilizerService.processAction(actionDto));
    this.spinnerStore.stopSpinner();
  }
}
