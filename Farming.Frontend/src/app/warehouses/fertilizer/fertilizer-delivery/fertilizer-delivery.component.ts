import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { DeliveryDto } from 'src/app/core/models/warehouse';
import { FertilizerWarehouseService } from 'src/app/core/services/fertilizer-warehouse.service';

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
  public cardContent: string;
  public objectTypeEnum = ObjectTypeEnum;

  private warehouseName: string;
  private fertilizerName: string;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private fertilizerWarehouseService: FertilizerWarehouseService
  ) {
    this.warehouseId = this.route.snapshot.paramMap.get('warehouseId');
    this.fertilizerId = this.route.snapshot.paramMap.get('fertilizerId');
  }

  async ngOnInit(): Promise<void> {
    await this.getFertilizerDelivery();
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

      this.cardContent = `Historia dostaw nawozu: ${this.fertilizerName}, na magazyn: ${this.warehouseName}`;
    } else {
      this.warehouseMode = true;
      this.deliveries = await lastValueFrom(
        this.fertilizerWarehouseService.getDeliveriesByWarehouse(this.warehouseId!)
      );

      this.cardContent = `Historia dostaw na magazyn: ${this.warehouseName}`;
    }
    this.canDisplay = true;
  }
}
