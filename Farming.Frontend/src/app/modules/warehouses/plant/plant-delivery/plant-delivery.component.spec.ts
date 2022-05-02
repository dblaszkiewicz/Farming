import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantDeliveryComponent } from './plant-delivery.component';

describe('PlantDeliveryComponent', () => {
  let component: PlantDeliveryComponent;
  let fixture: ComponentFixture<PlantDeliveryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantDeliveryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantDeliveryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
