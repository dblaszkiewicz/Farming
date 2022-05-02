import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  public loginForm: FormGroup;
  public isLoggedIn = false;

  constructor(store$: Store<{ auth: AuthState }>, private router: Router) {
    super(store$);
  }

  ngOnInit(): void {
    this.setForm();
    this.subscribeToIsLoggedIn();
  }

  public logIn() {
    this.store$.dispatch(
      AuthActions.login({
        login: this.loginForm.controls['login'].value,
        password: this.loginForm.controls['password'].value,
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

  private setForm(): void {
    this.loginForm = new FormGroup({
      login: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required),
    });
  }
}
