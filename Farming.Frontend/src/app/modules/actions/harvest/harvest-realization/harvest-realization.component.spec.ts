import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HarvestRealizationComponent } from './harvest-realization.component';

describe('HarvestRealizationComponent', () => {
  let component: HarvestRealizationComponent;
  let fixture: ComponentFixture<HarvestRealizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HarvestRealizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HarvestRealizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
