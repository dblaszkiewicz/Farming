import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { DeliveryDto } from 'src/app/core/models/warehouse';
import { PesticideWarehouseService } from 'src/app/core/services/pesticide-warehouse.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-pesticide-delivery',
  templateUrl: './pesticide-delivery.component.html',
  styleUrls: ['./pesticide-delivery.component.scss'],
})
export class PesticideDeliveryComponent implements OnInit {
  public warehouseId: string | null;
  public pesticideId: string | null;
  public deliveries: DeliveryDto[];
  public canDisplay: boolean = false;
  public warehouseMode: boolean = true;
  public cardContent: string;
  public averagePricePerLiter: number = 0;
  public objectTypeEnum = ObjectTypeEnum;

  private warehouseName: string;
  private pesticideName: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private pesticideWarehouseService: PesticideWarehouseService,
    private spinnerStore: SpinnerStore
  ) {
    this.warehouseId = this.route.snapshot.paramMap.get('warehouseId');
    this.pesticideId = this.route.snapshot.paramMap.get('pesticideId');
  }

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getPesticideDelivery();
    this.spinnerStore.stopSpinner();
  }

  public goBack(): void {
    this.router.navigateByUrl(`/warehouse/pesticide/${this.warehouseId}`);
  }

  private async getPesticideDelivery(): Promise<void> {
    this.warehouseName = await lastValueFrom(this.pesticideWarehouseService.getNameById(this.warehouseId!));

    if (this.warehouseId && this.pesticideId) {
      this.warehouseMode = false;
      const result = await lastValueFrom(
        this.pesticideWarehouseService.getDeliveriesByWarehouseAndFertilizer(this.warehouseId, this.pesticideId)
      );

      this.pesticideName = result.name;

      this.cardContent = `Historia dostaw oprysku: ${this.pesticideName}, na magazyn: ${this.warehouseName}`;

      this.deliveries = result.deliveries;
      this.averagePricePerLiter = result.averagePricePerLiter;
    } else {
      this.warehouseMode = true;
      this.cardContent = `Historia dostaw na magazyn: ${this.warehouseName}`;
      this.deliveries = await lastValueFrom(this.pesticideWarehouseService.getDeliveriesByWarehouse(this.warehouseId!));
    }
    this.canDisplay = true;
  }
}
