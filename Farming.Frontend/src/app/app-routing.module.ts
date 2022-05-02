import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./core/core.module').then(m => m.CoreModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'warehouse',
    loadChildren: () => import('./modules/warehouses/warehouses.module').then(m => m.WarehousesModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'action',
    loadChildren: () => import('./modules/actions/actions.module').then(m => m.ActionsModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'lands',
    loadChildren: () => import('./modules/lands/lands.module').then(m => m.LandsModule),
  },
  {
    canLoad: [AuthGuard],
    path: 'user',
    loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
