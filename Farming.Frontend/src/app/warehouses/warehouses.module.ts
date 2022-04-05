import { NgModule } from '@angular/core';

import { WarehousesRoutingModule } from './warehouses-routing.module';
import { PlantWarehouseComponent } from './plant-warehouse/plant-warehouse.component';
import { PesticideWarehouseComponent } from './pesticide-warehouse/pesticide-warehouse.component';
import { FertilizerWarehouseComponent } from './fertilizer-warehouse/fertilizer-warehouse.component';
import { SharedModule } from '../shared.module';
import { AddDeliveryDialogComponent } from './common/add-delivery-dialog/add-delivery-dialog.component';

@NgModule({
  declarations: [
    PlantWarehouseComponent,
    PesticideWarehouseComponent,
    FertilizerWarehouseComponent,
    AddDeliveryDialogComponent,
  ],
  imports: [WarehousesRoutingModule, SharedModule],
})
export class WarehousesModule {}
