import { NgModule } from '@angular/core';
import { CoreRoutingModule } from './core-routing.module';
import { SharedModule } from '../modules/shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { ContactComponent } from './components/contact/contact.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { MainAppComponent } from './components/main-app/main-app.component';
import { RegisterComponent } from './components/register/register.component';

@NgModule({
  declarations: [LoginComponent, ContactComponent, DashboardComponent, MainAppComponent, RegisterComponent],
  imports: [CoreRoutingModule, SharedModule],
  exports: [MainAppComponent],
})
export class CoreModule {}
