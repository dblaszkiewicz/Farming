import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActiveGuard } from '../core/guards/active.guard';
import { AdminGuard } from '../core/guards/admin.guard';
import { AuthGuard } from '../core/guards/auth.guard';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  {
    canActivate: [AuthGuard, ActiveGuard, AdminGuard],
    path: '',
    component: UsersComponent,
  },
  {
    canActivate: [AuthGuard],
    path: 'change-password',
    component: ChangePasswordComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}
