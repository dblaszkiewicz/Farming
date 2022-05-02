import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FertilizerRealizationComponent } from './fertilizer-realization.component';

describe('FertilizerRealizationComponent', () => {
  let component: FertilizerRealizationComponent;
  let fixture: ComponentFixture<FertilizerRealizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FertilizerRealizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FertilizerRealizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
