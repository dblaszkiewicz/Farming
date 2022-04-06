import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FertilizerWarehouseComponent } from './fertilizer-warehouse.component';

describe('FertilizerWarehouseComponent', () => {
  let component: FertilizerWarehouseComponent;
  let fixture: ComponentFixture<FertilizerWarehouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FertilizerWarehouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FertilizerWarehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
