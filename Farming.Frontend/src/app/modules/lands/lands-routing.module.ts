import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guards/auth.guard';
import { LandsPreviewComponent } from './lands-preview/lands-preview.component';

const routes: Routes = [
  {
    canActivate: [AuthGuard],
    path: '',
    component: LandsPreviewComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LandsRoutingModule {}
