import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AgriculturalActionsModule } from './agricultural-actions/agricultural-actions.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthModule } from './auth/auth.module';
import { CoreModule } from './core/core.module';
import { FieldsModule } from './fields/fields.module';
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared.module';
import { WarehousesModule } from './warehouses/warehouses.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AgriculturalActionsModule,
    AuthModule,
    CoreModule,
    FieldsModule,
    HomeModule,
    SharedModule,
    WarehousesModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
