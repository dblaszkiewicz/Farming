import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay, lastValueFrom } from 'rxjs';
import CustomValidation from '../../helpers/validators';
import { AddUserDto } from '../../models/user';
import { SnackbarService } from '../../services/snackbar.service';
import { UserService } from '../../services/user.service';
import { SpinnerStore } from '../../stores/spinner.store';

@UntilDestroy()
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public registerForm: FormGroup;
  public destkopMode: boolean = true;

  constructor(
    private router: Router,
    private spinnerStore: SpinnerStore,
    private observer: BreakpointObserver,
    private userService: UserService,
    private snackbarService: SnackbarService
  ) {
  }

  ngOnInit(): void {
    this.setForm();
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

  public async register() {
    const userToAdd: AddUserDto = {
      login: this.registerForm.controls['login'].value,
      name: this.registerForm.controls['name'].value,
      password: this.registerForm.controls['password'].value,
      repeatPassword: this.registerForm.controls['repeatPassword'].value,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.userService.register(userToAdd));
    this.spinnerStore.stopSpinner();
    this.snackbarService.showSuccess('Zarejestrowano pomyślnie');

    this.router.navigateByUrl('');
  }

  private setForm(): void {
    this.registerForm = new FormGroup(
      {
        name: new FormControl('', Validators.required),
        login: new FormControl('', [Validators.minLength(4), Validators.required]),
        password: new FormControl('', [Validators.minLength(6), Validators.maxLength(15), Validators.required]),
        repeatPassword: new FormControl('', Validators.required),
      },
      {
        validators: [
          CustomValidation.mustMatch('password', 'repeatPassword'),
          CustomValidation.passwordDifficulty('password'),
        ],
      }
    );
  }

}
