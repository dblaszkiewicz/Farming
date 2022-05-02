import { createSelector } from '@ngrx/store';
import { ApplicationState } from '..';
import { AuthState } from './auth.reducer';

export const selectAuthFeature = (state: ApplicationState) => state.auth;

export const selectIsLoggedIn = createSelector(selectAuthFeature, (state: AuthState) => state.isLoggedIn);

export const selectToken = createSelector(selectAuthFeature, (state: AuthState) => state.token);
