import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FertilizerRealizationComponent } from './fertilizer/fertilizer-realization/fertilizer-realization.component';
import { PesticideRealizationComponent } from './pesticide/pesticide-realization/pesticide-realization.component';
import { PlantRealizationComponent } from './plant/plant-realization/plant-realization.component';

const routes: Routes = [
  {
    path: 'fertilizer',
    component: FertilizerRealizationComponent,
  },
  {
    path: 'pesticide',
    component: PesticideRealizationComponent,
  },
  {
    path: 'plant',
    component: PlantRealizationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ActionsRoutingModule {}
