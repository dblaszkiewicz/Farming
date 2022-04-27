import { AbstractControl, ValidatorFn } from '@angular/forms';

export default class CustomValidation {
  static mustMatch(controlName: string, checkControlName: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(controlName);
      const checkControl = controls.get(checkControlName);
      if (checkControl?.errors && !checkControl.errors['mustMatch']) {
        return null;
      }
      if (control?.value !== checkControl?.value) {
        checkControl?.setErrors({ mustMatch: true });
        return { mustMatch: true };
      } else {
        checkControl?.setErrors(null);
        return null;
      }
    };
  }

  static passwordDifficulty(controlName: string): ValidatorFn {
    return (controls: AbstractControl) => {
      const control = controls.get(controlName);
      if (control?.errors && !control.errors['tooEasy']) {
        return null;
      }

      const value = control?.value as string;

      if (!value.match(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$/)) {
        controls.get(controlName)?.setErrors({ tooEasy: true });
        return { tooEasy: true };
      }

      return null;
    };
  }
}
