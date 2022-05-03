import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { UserDto } from 'src/app/core/models/user';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserService } from 'src/app/core/services/user.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';
import { AuthorizationService } from 'src/app/state/auth/authorization-service';
import { AddUserDialogComponent } from '../add-user-dialog/add-user-dialog.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss'],
})
export class UsersComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public users: UserDto[];
  public dataSource: MatTableDataSource<UserDto>;
  public currentUserId: string;
  public displayedColumns: string[] = ['name', 'login', 'created', 'active', 'isAdmin'];

  constructor(
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService,
    private userService: UserService,
    private matDialog: MatDialog,
    private authorizationService: AuthorizationService
  ) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getInitdata();
    this.spinnerStore.stopSpinner();
  }

  public async addUser(): Promise<void> {
    const dialogRef = this.matDialog.open(AddUserDialogComponent, {
      disableClose: true,
    });

    const result = await lastValueFrom(dialogRef.afterClosed());

    if (!result) {
      return;
    }

    this.spinnerStore.startSpinner();
    await this.getInitdata();
    this.spinnerStore.stopSpinner();
  }

  public async changeActiveMode(userId: string) {
    this.spinnerStore.startSpinner();
    await lastValueFrom(this.userService.changeActive(userId))
      .then(() => {
        this.snackbarService.showSuccess('Zmieniono aktywność');
      })
      .catch(async () => {
        this.spinnerStore.startSpinner();
        await this.getInitdata();
        this.spinnerStore.stopSpinner();
      });
    this.spinnerStore.stopSpinner();
  }

  public async changeAdminMode(userId: string) {
    this.spinnerStore.startSpinner();
    await lastValueFrom(this.userService.changeRole(userId))
      .then(() => {
        this.snackbarService.showSuccess('Zmieniono uprawnienia');
      })
      .catch(async () => {
        this.spinnerStore.startSpinner();
        await this.getInitdata();
        this.spinnerStore.stopSpinner();
      });
    this.spinnerStore.stopSpinner();
  }

  private async getInitdata(): Promise<void> {
    await this.getUsers();
    this.currentUserId = this.authorizationService.currentUserId();
    this.prepareGridData();
  }

  private async getUsers(): Promise<void> {
    this.users = await lastValueFrom(this.userService.getUsers());
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<UserDto>(this.users);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
