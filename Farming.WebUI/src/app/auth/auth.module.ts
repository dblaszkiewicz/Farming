import { NgModule } from '@angular/core';

import { AuthRoutingModule } from './auth-routing.module';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [],
  imports: [
    SharedModule,
    AuthRoutingModule
  ]
})
export class AuthModule { }
