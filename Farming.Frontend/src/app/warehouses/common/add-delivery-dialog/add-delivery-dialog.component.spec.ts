import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDeliveryDialogComponent } from './add-delivery-dialog.component';

describe('AddDeliveryDialogComponent', () => {
  let component: AddDeliveryDialogComponent;
  let fixture: ComponentFixture<AddDeliveryDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDeliveryDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDeliveryDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
