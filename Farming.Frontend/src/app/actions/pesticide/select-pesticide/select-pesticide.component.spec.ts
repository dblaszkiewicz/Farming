import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectPesticideComponent } from './select-pesticide.component';

describe('SelectPesticideComponent', () => {
  let component: SelectPesticideComponent;
  let fixture: ComponentFixture<SelectPesticideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectPesticideComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectPesticideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
