import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehousesRoutingModule } from './warehouses-routing.module';
import { PlantWarehouseComponent } from './plant-warehouse/plant-warehouse.component';
import { PesticideWarehouseComponent } from './pesticide-warehouse/pesticide-warehouse.component';
import { FertilizerWarehouseComponent } from './fertilizer-warehouse/fertilizer-warehouse.component';


@NgModule({
  declarations: [
    PlantWarehouseComponent,
    PesticideWarehouseComponent,
    FertilizerWarehouseComponent
  ],
  imports: [
    CommonModule,
    WarehousesRoutingModule
  ]
})
export class WarehousesModule { }
