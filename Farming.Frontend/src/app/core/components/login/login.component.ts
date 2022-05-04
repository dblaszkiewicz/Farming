import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { Store } from '@ngrx/store';
import { delay } from 'rxjs';
import { ApplicationState } from 'src/app/state';
import { AuthActions } from 'src/app/state/auth/auth.actions';
import { AuthState } from 'src/app/state/auth/auth.reducer';
import { selectIsLoggedIn } from 'src/app/state/auth/auth.selectors';
import StoreConnectedComponent from '../../../modules/utilities/store-connected.component';
import { SpinnerStore } from '../../stores/spinner.store';

@UntilDestroy()
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent extends StoreConnectedComponent<ApplicationState> implements OnInit, AfterViewInit {
  public loginForm: FormGroup;
  public isLoggedIn: boolean = false;
  public destkopMode: boolean = true;

  constructor(
    store$: Store<{ auth: AuthState }>,
    private router: Router,
    private spinnerStore: SpinnerStore,
    private observer: BreakpointObserver
  ) {
    super(store$);
  }

  ngOnInit(): void {
    this.setForm();
    this.subscribeToIsLoggedIn();
  }

  ngAfterViewInit(): void {
    this.observer
      .observe(['(max-width: 850px)'])
      .pipe(delay(1), untilDestroyed(this))
      .subscribe(res => {
        if (res.matches) {
          this.destkopMode = false;
        } else {
          this.destkopMode = true;
        }
      });
  }

  public logIn() {
    this.spinnerStore.startSpinner();
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
