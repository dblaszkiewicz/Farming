import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActiveGuard } from '../core/guards/active.guard';
import { AuthGuard } from '../core/guards/auth.guard';
import { FertilizerRealizationComponent } from './fertilizer/fertilizer-realization/fertilizer-realization.component';
import { HarvestRealizationComponent } from './harvest/harvest-realization/harvest-realization.component';
import { PesticideRealizationComponent } from './pesticide/pesticide-realization/pesticide-realization.component';
import { PlantRealizationComponent } from './plant/plant-realization/plant-realization.component';
import { ChangeSeasonComponent } from './season/change-season/change-season.component';
import { WeatherComponent } from './weather/weather.component';

const routes: Routes = [
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'fertilizer',
    component: FertilizerRealizationComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'pesticide',
    component: PesticideRealizationComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'plant',
    component: PlantRealizationComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'harvest',
    component: HarvestRealizationComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'season',
    component: ChangeSeasonComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: 'weather',
    component: WeatherComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ActionsRoutingModule {}
