import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LandsPreviewComponent } from './lands-preview.component';

describe('LandsPreviewComponent', () => {
  let component: LandsPreviewComponent;
  let fixture: ComponentFixture<LandsPreviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LandsPreviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LandsPreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
