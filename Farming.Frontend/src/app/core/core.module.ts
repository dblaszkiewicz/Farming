import { NgModule } from '@angular/core';
import { CoreRoutingModule } from './core-routing.module';
import { SharedModule } from '../modules/shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { ContactComponent } from './components/contact/contact.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';

@NgModule({
  declarations: [LoginComponent, ContactComponent, DashboardComponent],
  imports: [CoreRoutingModule, SharedModule],
})
export class CoreModule {}
