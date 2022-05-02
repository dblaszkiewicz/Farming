import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeSeasonComponent } from './change-season.component';

describe('ChangeSeasonComponent', () => {
  let component: ChangeSeasonComponent;
  let fixture: ComponentFixture<ChangeSeasonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeSeasonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeSeasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
