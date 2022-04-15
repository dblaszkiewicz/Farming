import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./general/general.module').then(m => m.GeneralModule),
  },
  {
    path: 'warehouse',
    loadChildren: () => import('./warehouses/warehouses.module').then(m => m.WarehousesModule),
  },
  {
    path: 'action',
    loadChildren: () => import('./actions/actions.module').then(m => m.ActionsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
