import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ActiveGuard } from '../core/guards/active.guard';
import { AuthGuard } from '../core/guards/auth.guard';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { NavigationComponent } from './navigation/navigation.component';

const routes: Routes = [
  {
    canActivate: [AuthGuard, ActiveGuard],
    path: '',
    component: NavigationComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class GeneralRoutingModule {}
