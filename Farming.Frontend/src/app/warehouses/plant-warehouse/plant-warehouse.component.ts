import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { PlantWarehouseDto } from 'src/app/core/models/warehouse';
import { PlantWarehouseService } from 'src/app/core/services/plant-warehouse.service';

@Component({
  selector: 'app-plant-warehouse',
  templateUrl: './plant-warehouse.component.html',
  styleUrls: ['./plant-warehouse.component.scss'],
})
export class PlantWarehouseComponent implements OnInit {
  public warehouses: PlantWarehouseDto[] = [];
  public selectedWarehouseId: string;

  constructor(private plantWarehouseService: PlantWarehouseService) {}

  async ngOnInit(): Promise<void> {
    await this.getInitData();
  }

  private async getInitData(): Promise<void> {
    await this.getWarehouses();
  }

  private async getWarehouses(): Promise<void> {
    this.warehouses = await lastValueFrom(this.plantWarehouseService.getAll());

    if (this.warehouses.length > 0) {
      this.selectedWarehouseId = this.warehouses[0].id;
    }
  }

  public warehouseChange(event: any): void {
    this.selectedWarehouseId = event.id;
  }
}
