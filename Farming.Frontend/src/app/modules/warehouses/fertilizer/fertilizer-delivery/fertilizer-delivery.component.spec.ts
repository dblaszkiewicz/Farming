import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FertilizerDeliveryComponent } from './fertilizer-delivery.component';

describe('FertilizerDeliveryComponent', () => {
  let component: FertilizerDeliveryComponent;
  let fixture: ComponentFixture<FertilizerDeliveryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FertilizerDeliveryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FertilizerDeliveryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
