import { NgModule } from '@angular/core';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { AuthEffects } from './auth/auth.effects';
import * as fromAuth from './auth/auth.reducer';

@NgModule({
  declarations: [],
  imports: [
    StoreModule.forFeature(fromAuth.authFeatureKey, fromAuth.authReducer),
    EffectsModule.forFeature([AuthEffects]),
  ],
})
export class StateModule {}
