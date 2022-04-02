import { NgModule } from '@angular/core';

import { HomeRoutingModule } from './home-routing.module';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [],
  imports: [
    SharedModule,
    HomeRoutingModule
  ]
})
export class HomeModule { }
