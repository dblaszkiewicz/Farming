import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, Validators } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay, lastValueFrom } from 'rxjs';
import CustomValidation from 'src/app/core/helpers/validators';
import { ChangePasswordDto } from 'src/app/core/models/user';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserService } from 'src/app/core/services/user.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@UntilDestroy()
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.scss'],
})
export class ChangePasswordComponent implements OnInit, AfterViewInit {
  @ViewChild(FormGroupDirective) formDirective: FormGroupDirective;

  public changePasswordForm: FormGroup;
  public destkopMode: boolean = false;

  constructor(
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService,
    private userService: UserService,
    private observer: BreakpointObserver
  ) {}

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

  ngOnInit(): void {
    this.setForm();
  }

  public async changePassword(): Promise<void> {
    const changePasswordDto: ChangePasswordDto = {
      oldPassword: this.changePasswordForm.controls['oldPassword'].value,
      newPassword: this.changePasswordForm.controls['newPassword'].value,
      repeatNewPassword: this.changePasswordForm.controls['repeatNewPassword'].value,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.userService.changePassword(changePasswordDto));
    this.spinnerStore.stopSpinner();
    this.snackbarService.showSuccess('Hasło zmienione pomyślnie');
    this.formDirective.resetForm();
  }

  private setForm(): void {
    this.changePasswordForm = new FormGroup(
      {
        oldPassword: new FormControl('', Validators.required),
        newPassword: new FormControl('', [Validators.minLength(6), Validators.maxLength(15), Validators.required]),
        repeatNewPassword: new FormControl('', Validators.required),
      },
      {
        validators: [
          CustomValidation.mustMatch('newPassword', 'repeatNewPassword'),
          CustomValidation.passwordDifficulty('newPassword'),
        ],
      }
    );
  }
}
