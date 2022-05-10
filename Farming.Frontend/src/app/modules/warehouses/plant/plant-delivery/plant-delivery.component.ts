import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { DeliveryDto } from 'src/app/core/models/warehouse';
import { PlantWarehouseService } from 'src/app/core/services/plant-warehouse.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-plant-delivery',
  templateUrl: './plant-delivery.component.html',
  styleUrls: ['./plant-delivery.component.scss'],
})
export class PlantDeliveryComponent implements OnInit {
  public warehouseId: string | null;
  public plantId: string | null;
  public deliveries: DeliveryDto[];
  public canDisplay: boolean = false;
  public warehouseMode: boolean = true;
  public objectTypeEnum = ObjectTypeEnum;

  public warehouseName: string;
  public plantName: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private plantWarehouseService: PlantWarehouseService,
    private spinnerStore: SpinnerStore
  ) {
    this.warehouseId = this.route.snapshot.paramMap.get('warehouseId');
    this.plantId = this.route.snapshot.paramMap.get('plantId');
  }

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getPlantDelivery();
    this.spinnerStore.stopSpinner();
  }

  public goBack(): void {
    this.router.navigateByUrl(`/warehouse/plant/${this.warehouseId}`);
  }

  private async getPlantDelivery(): Promise<void> {
    this.warehouseName = await lastValueFrom(this.plantWarehouseService.getNameById(this.warehouseId!));

    if (this.warehouseId && this.plantId) {
      this.warehouseMode = false;
      const result = await lastValueFrom(
        this.plantWarehouseService.getDeliveriesByWarehouseAndPlant(this.warehouseId, this.plantId)
      );

      this.plantName = result.name;
      this.deliveries = result.deliveries;
    } else {
      this.warehouseMode = true;
      this.deliveries = await lastValueFrom(this.plantWarehouseService.getDeliveriesByWarehouse(this.warehouseId!));
    }
    this.canDisplay = true;
  }
}
