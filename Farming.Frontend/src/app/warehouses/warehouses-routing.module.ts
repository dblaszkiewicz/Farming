import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FertilizerDeliveryComponent } from './fertilizer/fertilizer-delivery/fertilizer-delivery.component';
import { FertilizerWarehouseComponent } from './fertilizer/fertilizer-warehouse/fertilizer-warehouse.component';
import { PesticideDeliveryComponent } from './pesticide/pesticide-delivery/pesticide-delivery.component';
import { PesticideWarehouseComponent } from './pesticide/pesticide-warehouse/pesticide-warehouse.component';
import { PlantWarehouseComponent } from './plant-warehouse/plant-warehouse.component';

const routes: Routes = [
  {
    path: 'plant',
    component: PlantWarehouseComponent,
  },
  {
    path: 'pesticide',
    component: PesticideWarehouseComponent,
  },
  {
    path: 'pesticide/:id',
    component: PesticideWarehouseComponent,
  },
  {
    path: 'fertilizer',
    component: FertilizerWarehouseComponent,
  },
  {
    path: 'fertilizer/:id',
    component: FertilizerWarehouseComponent,
  },
  {
    path: 'fertilizer/delivery/:warehouseId',
    component: FertilizerDeliveryComponent,
  },
  {
    path: 'fertilizer/delivery/:warehouseId/:fertilizerId',
    component: FertilizerDeliveryComponent,
  },
  {
    path: 'pesticide/delivery/:warehouseId',
    component: PesticideDeliveryComponent,
  },
  {
    path: 'pesticide/delivery/:warehouseId/:pesticideId',
    component: PesticideDeliveryComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WarehousesRoutingModule {}
