import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { UserDto } from 'src/app/core/models/user';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { UserService } from 'src/app/core/services/user.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

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
  public displayedColumns: string[] = ['name', 'login', 'created', 'active', 'isAdmin'];

  constructor(
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService,
    private userService: UserService
  ) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getInitdata();
    this.spinnerStore.stopSpinner();
  }

  public async addUser(): Promise<void> {}

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
