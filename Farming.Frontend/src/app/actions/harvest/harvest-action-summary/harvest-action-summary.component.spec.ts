import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HarvestActionSummaryComponent } from './harvest-action-summary.component';

describe('HarvestActionSummaryComponent', () => {
  let component: HarvestActionSummaryComponent;
  let fixture: ComponentFixture<HarvestActionSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HarvestActionSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HarvestActionSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
