import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PesticideActionSummaryComponent } from './pesticide-action-summary.component';

describe('PesticideActionSummaryComponent', () => {
  let component: PesticideActionSummaryComponent;
  let fixture: ComponentFixture<PesticideActionSummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PesticideActionSummaryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PesticideActionSummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
