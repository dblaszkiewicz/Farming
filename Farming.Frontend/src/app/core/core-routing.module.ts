import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './components/contact/contact.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ActiveGuard } from './guards/active.guard';
import { AuthGuard } from './guards/auth.guard';
import { RegisterComponent } from './components/register/register.component';
import { NoAuthorizeGuard } from './guards/no-authorize.guard';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: '',
    component: DashboardComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    canActivate: [NoAuthorizeGuard],
    path: 'register',
    component: RegisterComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CoreRoutingModule {}
