import { authFeatureKey, AuthState } from './auth/auth.reducer';

export interface ApplicationState {
  [authFeatureKey]: AuthState;
}
