import { FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

export class CustomErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    if (!control) {
      return false;
    }

    const isSubmitted = form && form.submitted;
    const isControlChangedOrSubmitted = control.dirty || control.touched || isSubmitted;

    return !!(control && control.invalid && isControlChangedOrSubmitted);
  }
}
