import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { DeliveryDto } from 'src/app/core/models/warehouse';
import { FertilizerWarehouseService } from 'src/app/core/services/fertilizer-warehouse.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-fertilizer-delivery',
  templateUrl: './fertilizer-delivery.component.html',
  styleUrls: ['./fertilizer-delivery.component.scss'],
})
export class FertilizerDeliveryComponent implements OnInit {
  public warehouseId: string | null;
  public fertilizerId: string | null;
  public deliveries: DeliveryDto[];
  public canDisplay: boolean = false;
  public warehouseMode: boolean = true;
  public averagePricePerTon: number;
  public objectTypeEnum = ObjectTypeEnum;

  public warehouseName: string;
  public fertilizerName: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fertilizerWarehouseService: FertilizerWarehouseService,
    private spinnerStore: SpinnerStore
  ) {
    this.warehouseId = this.route.snapshot.paramMap.get('warehouseId');
    this.fertilizerId = this.route.snapshot.paramMap.get('fertilizerId');
  }

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getFertilizerDelivery();
    this.spinnerStore.stopSpinner();
  }

  public goBack(): void {
    this.router.navigateByUrl(`/warehouse/fertilizer/${this.warehouseId}`);
  }

  private async getFertilizerDelivery(): Promise<void> {
    this.warehouseName = await lastValueFrom(this.fertilizerWarehouseService.getNameById(this.warehouseId!));

    if (this.warehouseId && this.fertilizerId) {
      this.warehouseMode = false;
      const result = await lastValueFrom(
        this.fertilizerWarehouseService.getDeliveriesByWarehouseAndFertilizer(this.warehouseId, this.fertilizerId)
      );

      this.fertilizerName = result.name;
      this.deliveries = result.deliveries;
      this.averagePricePerTon = result.averagePricePerTon;
    } else {
      this.warehouseMode = true;
      this.deliveries = await lastValueFrom(
        this.fertilizerWarehouseService.getDeliveriesByWarehouse(this.warehouseId!)
      );
    }
    this.canDisplay = true;
  }
}
