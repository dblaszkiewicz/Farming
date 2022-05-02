import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantActionSummaryComponent } from './plant-action-summary.component';

describe('PlantActionSummaryComponent', () => {
  let component: PlantActionSummaryComponent;
  let fixture: ComponentFixture<PlantActionSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantActionSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantActionSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
