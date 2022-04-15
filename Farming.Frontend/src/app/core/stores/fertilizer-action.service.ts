import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, lastValueFrom, of as observableOf } from 'rxjs';
import { FertilizerActionDto, FertilizerDto, FertilizerStateDto } from '../models/fertilizer';
import { LandDto } from '../models/land';
import { LandService } from '../services/farm-field.service';
import {} from 'rxjs';
import { FertilizerWarehouseDto } from '../models/warehouse';
import { FertilizerWarehouseService } from '../services/fertilizer-warehouse.service';
import { FertilizerService } from '../services/fertilizer.service';

@Injectable({
  providedIn: 'root',
})
export class FertilizerActionService {
  private selectedLand: LandDto | null;
  private selectedFertilizer: FertilizerStateDto | null;
  private selectedWarehouse: FertilizerWarehouseDto | null;

  private canGoToNextPanel: BehaviorSubject<boolean>;

  private lands: LandDto[] = [];
  private fertilizerStates: FertilizerStateDto[] = [];
  private warehouses: FertilizerWarehouseDto[] = [];

  constructor(
    private landService: LandService,
    private fertilizerWarehouseService: FertilizerWarehouseService,
    private fertilizerService: FertilizerService
  ) {
    this.canGoToNextPanel = new BehaviorSubject<boolean>(false);
  }

  public resetStore(): void {
    this.selectedLand = null;
    this.selectedFertilizer = null;
    this.selectedWarehouse = null;
    this.lands = [];
    this.fertilizerStates = [];
    this.canGoToNextPanel.next(false);
  }

  public canGoNext(): Observable<boolean> {
    return this.canGoToNextPanel.asObservable();
  }

  public getSelectedLand(): LandDto | null {
    return this.selectedLand;
  }

  public getSelectedFertilizer(): FertilizerStateDto | null {
    return this.selectedFertilizer;
  }

  public getSelectedWarehouse(): FertilizerWarehouseDto | null {
    return this.selectedWarehouse;
  }

  public setSelectedLand(land: LandDto | null): void {
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

  public getLands(): LandDto[] {
    return this.lands;
  }

  public getFertilizerStates(): FertilizerStateDto[] {
    return this.fertilizerStates;
  }

  public async prepareLands(): Promise<void> {
    if (this.lands.length > 0) {
      return;
    }
    this.canGoToNextPanel.next(false);
    this.lands = await lastValueFrom(this.landService.getAll());
  }

  public setCanGoNext(canGoNext: boolean): void {
    this.canGoToNextPanel.next(canGoNext);
  }

  private async prepareFertilziers(): Promise<void> {
    this.canGoToNextPanel.next(false);

    if (this.fertilizerStates.length > 0) {
      return;
    }

    this.selectedFertilizer = null;

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
  }

  public async prepareWarehouses(): Promise<void> {
    if (this.warehouses.length > 0) {
      return;
    }
    this.warehouses = await lastValueFrom(this.fertilizerWarehouseService.getAll());
  }

  public getWarehouses(): FertilizerWarehouseDto[] {
    return this.warehouses;
  }

  public async processAction(): Promise<void> {
    const requiredAmount = this.selectedLand?.area! * this.selectedFertilizer?.enoughForArea!;

    const actionDto: FertilizerActionDto = {
      fertilizerId: this.selectedFertilizer?.fertilizerId!,
      fertilizerWarehouseId: this.selectedWarehouse?.id!,
      landId: this.selectedLand?.id!,
      quantity: requiredAmount,
    };

    await lastValueFrom(this.fertilizerService.processAction(actionDto));
  }
}
