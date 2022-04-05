import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AddDeliveryDto } from 'src/app/core/models/warehouse';

@Component({
  selector: 'app-add-delivery-dialog',
  templateUrl: './add-delivery-dialog.component.html',
  styleUrls: ['./add-delivery-dialog.component.scss'],
})
export class AddDeliveryDialogComponent implements OnInit {
  public form: FormGroup;

  constructor(@Inject(MAT_DIALOG_DATA) public data: { name: string; typeName: string }) {
    this.setForm();
  }

  ngOnInit(): void {}

  public addDelivery(): AddDeliveryDto {
    return {
      price: this.form.controls['price'].value,
      quantity: this.form.controls['quantity'].value,
    };
  }

  private setForm(): void {
    this.form = new FormGroup({
      quantity: new FormControl(null, Validators.required),
      price: new FormControl(null, Validators.required),
    });
  }
}
