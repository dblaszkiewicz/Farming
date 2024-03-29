import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActionsRoutingModule } from './actions-routing.module';
import { FertilizerRealizationComponent } from './fertilizer/fertilizer-realization/fertilizer-realization.component';
import { SelectLandForFertilizerComponent } from './fertilizer/select-land-for-fertilizer/select-land-for-fertilizer.component';
import { SharedModule } from '../shared/shared.module';
import { SelectFertilizerComponent } from './fertilizer/select-fertilizer/select-fertilizer.component';
import { FertilizerActionSummaryComponent } from './fertilizer/fertilizer-action-summary/fertilizer-action-summary.component';
import { PesticideRealizationComponent } from './pesticide/pesticide-realization/pesticide-realization.component';
import { SelectPesticideComponent } from './pesticide/select-pesticide/select-pesticide.component';
import { SelectLandForPesticideComponent } from './pesticide/select-land-for-pesticide/select-land-for-pesticide.component';
import { PesticideActionSummaryComponent } from './pesticide/pesticide-action-summary/pesticide-action-summary.component';
import { PlantRealizationComponent } from './plant/plant-realization/plant-realization.component';
import { PlantActionSummaryComponent } from './plant/plant-action-summary/plant-action-summary.component';
import { SelectPlantComponent } from './plant/select-plant/select-plant.component';
import { SelectLandForPlantComponent } from './plant/select-land-for-plant/select-land-for-plant.component';
import { HarvestRealizationComponent } from './harvest/harvest-realization/harvest-realization.component';
import { SelectLandForHarvestComponent } from './harvest/select-land-for-harvest/select-land-for-harvest.component';
import { HarvestActionSummaryComponent } from './harvest/harvest-action-summary/harvest-action-summary.component';
import { ChangeSeasonComponent } from './season/change-season/change-season.component';
import { WeatherComponent } from './weather/weather.component';

@NgModule({
  declarations: [
    FertilizerRealizationComponent,
    SelectLandForFertilizerComponent,
    SelectFertilizerComponent,
    FertilizerActionSummaryComponent,
    PesticideRealizationComponent,
    SelectPesticideComponent,
    SelectLandForPesticideComponent,
    PesticideActionSummaryComponent,
    PlantRealizationComponent,
    PlantActionSummaryComponent,
    SelectPlantComponent,
    SelectLandForPlantComponent,
    HarvestRealizationComponent,
    SelectLandForHarvestComponent,
    HarvestActionSummaryComponent,
    ChangeSeasonComponent,
    WeatherComponent,
  ],
  imports: [CommonModule, ActionsRoutingModule, SharedModule],
})
export class ActionsModule {}
