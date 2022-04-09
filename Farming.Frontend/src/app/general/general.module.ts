import { NgModule } from '@angular/core';

import { GeneralRoutingModule } from './general-routing.module';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    HomeComponent,
    ContactComponent
  ],
  imports: [
    GeneralRoutingModule,
    SharedModule
  ]
})
export class GeneralModule { }
