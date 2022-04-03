import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantWarehouseComponent } from './plant-warehouse.component';

describe('PlantWarehouseComponent', () => {
  let component: PlantWarehouseComponent;
  let fixture: ComponentFixture<PlantWarehouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantWarehouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantWarehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
