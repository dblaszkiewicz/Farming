import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { SharedModule } from './shared.module';
import { CoreModule } from './core/core.module';
import { WarehousesModule } from './warehouses/warehouses.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserAnimationsModule,
    SharedModule,
    CoreModule,
    WarehousesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
