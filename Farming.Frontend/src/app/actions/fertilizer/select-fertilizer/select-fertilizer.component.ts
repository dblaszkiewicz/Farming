import { Component, OnInit } from '@angular/core';
import { FertilizerStateDto } from 'src/app/core/models/fertilizer';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { FertilizerWarehouseDto } from 'src/app/core/models/warehouse';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';

@Component({
  selector: 'app-select-fertilizer',
  templateUrl: './select-fertilizer.component.html',
  styleUrls: ['./select-fertilizer.component.scss'],
})
export class SelectFertilizerComponent implements RealizationComponentInterface, OnInit {
  constructor(private fertilizerActionService: FertilizerActionService) {}

  public selectedWarehouseId: string;
  public selectedFertilizerId: string | null;

  public selectedWarehouse: FertilizerWarehouseDto | null;
  public selectedFertilizer: FertilizerStateDto | null;

  public warehouses: FertilizerWarehouseDto[];
  public fertilizerStates: FertilizerStateDto[];

  async ngOnInit(): Promise<void> {
    await this.getWarehouses();
    await this.trySetSelectedWarehouse();
  }

  private async getWarehouses(): Promise<void> {
    await this.fertilizerActionService.prepareWarehouses();
    this.warehouses = this.fertilizerActionService.getWarehouses();
    if (this.warehouses.length === 1) {
      this.selectedWarehouse = this.warehouses[0];
      this.selectedWarehouseId = this.selectedWarehouse.id;
      this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
    }
  }

  private async trySetSelectedWarehouse() {
    const warehouse = this.fertilizerActionService.getSelectedWarehouse();
    if (warehouse) {
      this.selectedWarehouse = warehouse!;
      this.selectedWarehouseId = warehouse.id;
      await this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.fertilizerStates = this.fertilizerActionService.getFertilizerStates();
      this.trySetSelectedFertilizer();
    } else {
      this.fertilizerActionService.setSelectedWarehouse(null);
    }
  }

  private async trySetSelectedFertilizer() {
    const fertilizer = this.fertilizerActionService.getSelectedFertilizer();

    if (fertilizer) {
      this.selectedFertilizer = fertilizer!;
      this.selectedFertilizerId = fertilizer.fertilizerId!;
      this.fertilizerActionService.setSelectedFertilizer(this.selectedFertilizer);
      this.fertilizerActionService.setCanGoNext(true);
    } else {
      this.fertilizerActionService.setSelectedFertilizer(null);
    }
  }

  public async warehouseChange() {
    this.selectedWarehouse = this.warehouses.find(x => x.id === this.selectedWarehouseId)!;
    await this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
    this.selectedFertilizer = null;
    this.selectedFertilizerId = null;
    this.fertilizerActionService.setSelectedFertilizer(null);
    this.fertilizerStates = this.fertilizerActionService.getFertilizerStates();
  }

  public fertilizerChange() {
    this.selectedFertilizer = this.fertilizerStates.find(x => x.fertilizerId === this.selectedFertilizerId)!;
    this.fertilizerActionService.setSelectedFertilizer(this.selectedFertilizer);

    const land = this.fertilizerActionService.getSelectedLand();

    if (this.selectedFertilizer.enoughForArea >= land?.area!) {
      this.fertilizerActionService.setCanGoNext(true);
    } else {
      this.fertilizerActionService.setCanGoNext(false);
    }
  }
}
