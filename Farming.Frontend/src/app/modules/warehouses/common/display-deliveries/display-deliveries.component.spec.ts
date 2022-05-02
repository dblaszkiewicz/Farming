import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayDeliveriesComponent } from './display-deliveries.component';

describe('DisplayDeliveriesComponent', () => {
  let component: DisplayDeliveriesComponent;
  let fixture: ComponentFixture<DisplayDeliveriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayDeliveriesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayDeliveriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
