import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PesticideWarehouseComponent } from './pesticide-warehouse.component';

describe('PesticideWarehouseComponent', () => {
  let component: PesticideWarehouseComponent;
  let fixture: ComponentFixture<PesticideWarehouseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PesticideWarehouseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PesticideWarehouseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
