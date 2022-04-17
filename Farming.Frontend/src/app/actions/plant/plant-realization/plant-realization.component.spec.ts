import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlantRealizationComponent } from './plant-realization.component';

describe('PlantRealizationComponent', () => {
  let component: PlantRealizationComponent;
  let fixture: ComponentFixture<PlantRealizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlantRealizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlantRealizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
