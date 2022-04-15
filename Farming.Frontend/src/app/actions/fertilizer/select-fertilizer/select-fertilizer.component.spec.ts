import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectFertilizerComponent } from './select-fertilizer.component';

describe('SelectFertilizerComponent', () => {
  let component: SelectFertilizerComponent;
  let fixture: ComponentFixture<SelectFertilizerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectFertilizerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectFertilizerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
