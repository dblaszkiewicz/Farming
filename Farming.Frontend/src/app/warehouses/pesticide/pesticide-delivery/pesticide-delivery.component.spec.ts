import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PesticideDeliveryComponent } from './pesticide-delivery.component';

describe('PesticideDeliveryComponent', () => {
  let component: PesticideDeliveryComponent;
  let fixture: ComponentFixture<PesticideDeliveryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PesticideDeliveryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PesticideDeliveryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
