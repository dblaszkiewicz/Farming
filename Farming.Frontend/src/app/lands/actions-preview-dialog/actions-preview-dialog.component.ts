import { Inject, ViewChild } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { AfterViewInit } from '@angular/core';
import { Component } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { LandActionDto } from 'src/app/core/models/land';

@Component({
  selector: 'app-actions-preview-dialog',
  templateUrl: './actions-preview-dialog.component.html',
  styleUrls: ['./actions-preview-dialog.component.scss'],
})
export class ActionsPreviewDialogComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public dataSource: MatTableDataSource<LandActionDto>;

  public displayedColumns: string[] = ['name', 'quantity', 'realizationDate', 'userName'];

  constructor(@Inject(MAT_DIALOG_DATA) public data: LandActionDto[], private cdr: ChangeDetectorRef) {}

  ngAfterViewInit(): void {
    this.prepareGridData();
    this.cdr.detectChanges();
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<LandActionDto>(this.data);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
