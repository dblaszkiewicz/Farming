import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectLandForPlantComponent } from './select-land-for-plant.component';

describe('SelectLandForPlantComponent', () => {
  let component: SelectLandForPlantComponent;
  let fixture: ComponentFixture<SelectLandForPlantComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectLandForPlantComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectLandForPlantComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
