import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProgressSpinnerComponent } from './progress-spinner/progress-spinner.component';
import { DynamicPanelDirective } from './directives/dynamic-panel.directive';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';

const modules = [CommonModule, MaterialModule, FormsModule, ReactiveFormsModule];

const components = [ProgressSpinnerComponent, ConfirmDialogComponent];

const directives = [DynamicPanelDirective];

@NgModule({
  declarations: [...components, ...directives],
  imports: [...modules],
  exports: [...modules, ...components, ...directives],
})
export class SharedModule {}
