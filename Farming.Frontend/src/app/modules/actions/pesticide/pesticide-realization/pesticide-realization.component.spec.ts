import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PesticideRealizationComponent } from './pesticide-realization.component';

describe('PesticideRealizationComponent', () => {
  let component: PesticideRealizationComponent;
  let fixture: ComponentFixture<PesticideRealizationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PesticideRealizationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PesticideRealizationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
