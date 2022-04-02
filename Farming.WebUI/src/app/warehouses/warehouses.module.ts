import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WarehousesRoutingModule } from './warehouses-routing.module';
import { SharedModule } from '../shared.module';


@NgModule({
  declarations: [],
  imports: [
    SharedModule,
    CommonModule,
    WarehousesRoutingModule
  ]
})
export class WarehousesModule { }
