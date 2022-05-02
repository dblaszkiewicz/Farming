import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActiveGuard } from 'src/app/core/guards/active.guard';
import { AuthGuard } from 'src/app/core/guards/auth.guard';
import { FertilizerDeliveryComponent } from './fertilizer/fertilizer-delivery/fertilizer-delivery.component';
import { FertilizerWarehouseComponent } from './fertilizer/fertilizer-warehouse/fertilizer-warehouse.component';
import { PesticideDeliveryComponent } from './pesticide/pesticide-delivery/pesticide-delivery.component';
import { PesticideWarehouseComponent } from './pesticide/pesticide-warehouse/pesticide-warehouse.component';
import { PlantDeliveryComponent } from './plant/plant-delivery/plant-delivery.component';
import { PlantWarehouseComponent } from './plant/plant-warehouse/plant-warehouse.component';

const routes: Routes = [
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'plant',
    component: PlantWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'plant/:id',
    component: PlantWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'pesticide',
    component: PesticideWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'pesticide/:id',
    component: PesticideWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'fertilizer',
    component: FertilizerWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'fertilizer/:id',
    component: FertilizerWarehouseComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'fertilizer/delivery/:warehouseId',
    component: FertilizerDeliveryComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'fertilizer/delivery/:warehouseId/:fertilizerId',
    component: FertilizerDeliveryComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'pesticide/delivery/:warehouseId',
    component: PesticideDeliveryComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'pesticide/delivery/:warehouseId/:pesticideId',
    component: PesticideDeliveryComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'plant/delivery/:warehouseId',
    component: PlantDeliveryComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'plant/delivery/:warehouseId/:plantId',
    component: PlantDeliveryComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WarehousesRoutingModule {}
