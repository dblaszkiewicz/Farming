import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FertilizerActionSummaryComponent } from './fertilizer-action-summary.component';

describe('FertilizerActionSummaryComponent', () => {
  let component: FertilizerActionSummaryComponent;
  let fixture: ComponentFixture<FertilizerActionSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FertilizerActionSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FertilizerActionSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
