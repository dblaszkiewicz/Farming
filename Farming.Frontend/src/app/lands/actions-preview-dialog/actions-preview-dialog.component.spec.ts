import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ActionsPreviewDialogComponent } from './actions-preview-dialog.component';

describe('ActionsPreviewDialogComponent', () => {
  let component: ActionsPreviewDialogComponent;
  let fixture: ComponentFixture<ActionsPreviewDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ActionsPreviewDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ActionsPreviewDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
