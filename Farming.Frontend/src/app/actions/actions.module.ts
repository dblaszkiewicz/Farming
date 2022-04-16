import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ActionsRoutingModule } from './actions-routing.module';
import { FertilizerRealizationComponent } from './fertilizer/fertilizer-realization/fertilizer-realization.component';
import { SelectLandForFertilizerComponent } from './fertilizer/select-land-for-fertilizer/select-land-for-fertilizer.component';
import { SharedModule } from '../shared/shared.module';
import { SelectFertilizerComponent } from './fertilizer/select-fertilizer/select-fertilizer.component';
import { FertilizerActionSummaryComponent } from './fertilizer/fertilizer-action-summary/fertilizer-action-summary.component';

@NgModule({
  declarations: [
    FertilizerRealizationComponent,
    SelectLandForFertilizerComponent,
    SelectFertilizerComponent,
    FertilizerActionSummaryComponent,
  ],
  imports: [CommonModule, ActionsRoutingModule, SharedModule],
})
export class ActionsModule {}
