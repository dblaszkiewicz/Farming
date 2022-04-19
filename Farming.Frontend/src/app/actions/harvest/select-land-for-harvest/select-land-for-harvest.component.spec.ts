import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectLandForHarvestComponent } from './select-land-for-harvest.component';

describe('SelectLandForHarvestComponent', () => {
  let component: SelectLandForHarvestComponent;
  let fixture: ComponentFixture<SelectLandForHarvestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectLandForHarvestComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectLandForHarvestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
