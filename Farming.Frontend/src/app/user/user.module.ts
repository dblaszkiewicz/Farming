import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UsersComponent } from './users/users.component';
import { SharedModule } from '../shared/shared.module';
import { AddUserDialogComponent } from './add-user-dialog/add-user-dialog.component';

@NgModule({
  declarations: [UsersComponent, AddUserDialogComponent],
  imports: [CommonModule, UserRoutingModule, SharedModule],
})
export class UserModule {}
