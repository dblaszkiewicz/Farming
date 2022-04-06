import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'warehouse',
    loadChildren: () => import('./warehouses/warehouses.module').then(m => m.WarehousesModule),
  },
  {
    path: 'general',
    loadChildren: () => import('./general/general.module').then(m => m.GeneralModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
