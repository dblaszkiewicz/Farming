import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectLandForPesticideComponent } from './select-land-for-pesticide.component';

describe('SelectLandForPesticideComponent', () => {
  let component: SelectLandForPesticideComponent;
  let fixture: ComponentFixture<SelectLandForPesticideComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectLandForPesticideComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectLandForPesticideComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
