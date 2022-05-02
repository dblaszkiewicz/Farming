import { createAction, props } from '@ngrx/store';
import { LogInDto, LogInSuccessDto } from '../../core/models/login';

const loginRequestedType = '[Login Component] Login requested';
const loginSuccessType = '[Login Component] Login success';
const loginFailedType = '[Login Component] Login failed';

const logoutRequestedType = '[Login Component] Logout requested';
const logoutSuccessType = '[Login Component] Logout success';
const logoutFailedType = '[Login Component] Logout failed';

const login = createAction(loginRequestedType, props<LogInDto>());
const loginSuccess = createAction(loginSuccessType, props<LogInSuccessDto>());
const loginFailed = createAction(loginFailedType);

const logout = createAction(logoutRequestedType);
const logoutSuccess = createAction(logoutSuccessType);
const logoutFailed = createAction(logoutFailedType);

export const AuthActions = {
  login,
  loginSuccess,
  loginFailed,
  logout,
  logoutSuccess,
  logoutFailed,
};
