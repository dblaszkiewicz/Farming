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
  {
    path: 'lands',
    loadChildren: () => import('./lands/lands.module').then(m => m.LandsModule),
  },
  {
    path: 'user',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
