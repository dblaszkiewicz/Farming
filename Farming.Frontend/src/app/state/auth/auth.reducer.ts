import { createReducer, on } from '@ngrx/store';
import { AuthActions } from './auth.actions';

export const authFeatureKey = 'auth';

export const initialState: AuthState = {
  token: '',
  isLoggedIn: false,
  isActionInProgress: false,
};

const _authReducer = createReducer(
  initialState,
  on(AuthActions.login, state => ({
    ...state,
    isActionInProgress: true,
  })),
  on(AuthActions.loginSuccess, (state, { token }) => ({
    ...state,
    token,
    isLoggedIn: true,
    isActionInProgress: false,
  })),
  on(AuthActions.loginFailed, state => ({
    ...state,
    isActionInProgress: false,
  })),
  on(AuthActions.logout, state => ({
    ...state,
    isActionInProgress: true,
  })),
  on(AuthActions.logoutSuccess, state => ({
    ...state,
    token: '',
    isLoggedIn: false,
    isActionInProgress: false,
  })),
  on(AuthActions.logoutFailed, state => ({
    ...state,
    isActionInProgress: false,
  }))
);

export function authReducer(state: AuthState = initialState, action: any) {
  return _authReducer(state, action);
}

export interface AuthState {
  token: string;
  isLoggedIn: boolean;
  isActionInProgress: boolean;
}
