import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FertilizerRealizationComponent } from './fertilizer/fertilizer-realization/fertilizer-realization.component';

const routes: Routes = [
  {
    path: 'fertilizer',
    component: FertilizerRealizationComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ActionsRoutingModule {}
