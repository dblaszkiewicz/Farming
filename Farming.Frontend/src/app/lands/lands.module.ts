import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LandsRoutingModule } from './lands-routing.module';
import { LandsPreviewComponent } from './lands-preview/lands-preview.component';
import { SharedModule } from '../shared/shared.module';
import { ActionsPreviewDialogComponent } from './actions-preview-dialog/actions-preview-dialog.component';

@NgModule({
  declarations: [LandsPreviewComponent, ActionsPreviewDialogComponent],
  imports: [CommonModule, LandsRoutingModule, SharedModule],
})
export class LandsModule {}
