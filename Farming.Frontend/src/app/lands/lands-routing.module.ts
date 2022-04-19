import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandsPreviewComponent } from './lands-preview/lands-preview.component';

const routes: Routes = [
  {
    path: '',
    component: LandsPreviewComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LandsRoutingModule {}
