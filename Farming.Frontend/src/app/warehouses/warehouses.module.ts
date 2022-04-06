import { NgModule } from '@angular/core';

import { WarehousesRoutingModule } from './warehouses-routing.module';
import { PlantWarehouseComponent } from './plant-warehouse/plant-warehouse.component';
import { PesticideWarehouseComponent } from './pesticide-warehouse/pesticide-warehouse.component';
import { FertilizerWarehouseComponent } from './fertilizer/fertilizer-warehouse/fertilizer-warehouse.component';
import { SharedModule } from '../shared.module';
import { AddDeliveryDialogComponent } from './common/add-delivery-dialog/add-delivery-dialog.component';
import { FertilizerDeliveryComponent } from './fertilizer/fertilizer-delivery/fertilizer-delivery.component';
import { DisplayDeliveriesComponent } from './common/display-deliveries/display-deliveries.component';

@NgModule({
  declarations: [
    PlantWarehouseComponent,
    PesticideWarehouseComponent,
    FertilizerWarehouseComponent,
    AddDeliveryDialogComponent,
    FertilizerDeliveryComponent,
    DisplayDeliveriesComponent,
  ],
  imports: [WarehousesRoutingModule, SharedModule],
})
export class WarehousesModule {}
