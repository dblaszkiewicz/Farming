import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { ApplicationState } from 'src/app/state';
import { AuthActions } from 'src/app/state/auth/auth.actions';
import { AuthState } from 'src/app/state/auth/auth.reducer';
import { selectIsLoggedIn } from 'src/app/state/auth/auth.selectors';
import StoreConnectedComponent from '../../../modules/utilities/store-connected.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent extends StoreConnectedComponent<ApplicationState> implements OnInit {
  public loginFormControl = new FormControl('', [Validators.required]);
  public passwordFormControl = new FormControl('', [Validators.required]);

  public isLoggedIn = false;

  constructor(store$: Store<{ auth: AuthState }>, private router: Router) {
    super(store$);
  }

  ngOnInit(): void {
    this.subscribeToIsLoggedIn();
  }

  public logIn() {
    this.store$.dispatch(
      AuthActions.login({
        login: this.loginFormControl.value,
        password: this.passwordFormControl.value,
      })
    );
  }

  private subscribeToIsLoggedIn(): void {
    this.safeSelect$(selectIsLoggedIn).subscribe(isLoggedIn => {
      this.isLoggedIn = isLoggedIn;

      if (this.isLoggedIn) {
        this.router.navigateByUrl('');
      }
    });
  }
}
