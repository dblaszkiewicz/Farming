import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectLandForFertilizerComponent } from './select-land-for-fertilizer.component';

describe('SelectLandForFertilizerComponent', () => {
  let component: SelectLandForFertilizerComponent;
  let fixture: ComponentFixture<SelectLandForFertilizerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SelectLandForFertilizerComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectLandForFertilizerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
