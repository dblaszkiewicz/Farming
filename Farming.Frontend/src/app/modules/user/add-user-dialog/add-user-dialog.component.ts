import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { lastValueFrom } from 'rxjs';
import CustomValidation from 'src/app/core/helpers/validators';
import { AddUserDto } from 'src/app/core/models/user';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserService } from 'src/app/core/services/user.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-add-user-dialog',
  templateUrl: './add-user-dialog.component.html',
  styleUrls: ['./add-user-dialog.component.scss'],
})
export class AddUserDialogComponent {
  public addUserForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<AddUserDialogComponent>,
    private spinnerStore: SpinnerStore,
    private userService: UserService,
    private snackbarService: SnackbarService
  ) {
    this.setForm();
  }

  public async addUser(): Promise<void> {
    const userToAdd: AddUserDto = {
      login: this.addUserForm.controls['login'].value,
      name: this.addUserForm.controls['name'].value,
      password: this.addUserForm.controls['password'].value,
      repeatPassword: this.addUserForm.controls['repeatPassword'].value,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.userService.addUser(userToAdd));
    await this.snackbarService.showSuccess('AddUser.Success');
    this.spinnerStore.stopSpinner();

    this.dialogRef.close(true);
  }

  private setForm(): void {
    this.addUserForm = new FormGroup(
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
