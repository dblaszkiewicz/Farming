import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FertilizerWarehouseComponent } from './fertilizer-warehouse/fertilizer-warehouse.component';
import { PesticideWarehouseComponent } from './pesticide-warehouse/pesticide-warehouse.component';
import { PlantWarehouseComponent } from './plant-warehouse/plant-warehouse.component';

const routes: Routes = [
  {
    path: 'plant',
    component: PlantWarehouseComponent
  },
  {
    path: 'pesticide',
    component: PesticideWarehouseComponent
  },
  {
    path: 'fertilizer',
    component: FertilizerWarehouseComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WarehousesRoutingModule { }
