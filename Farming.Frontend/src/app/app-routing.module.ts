import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./general/general.module').then(m => m.GeneralModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'warehouse',
    loadChildren: () => import('./warehouses/warehouses.module').then(m => m.WarehousesModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'action',
    loadChildren: () => import('./actions/actions.module').then(m => m.ActionsModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'lands',
    loadChildren: () => import('./lands/lands.module').then(m => m.LandsModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'user',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
