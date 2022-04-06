import { AfterViewInit } from '@angular/core';
import { Input, ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeliveryDto } from 'src/app/core/models/warehouse';

@Component({
  selector: 'app-display-deliveries',
  templateUrl: './display-deliveries.component.html',
  styleUrls: ['./display-deliveries.component.scss'],
})
export class DisplayDeliveriesComponent implements AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input() public deliveries: DeliveryDto[];
  @Input() public warehouseMode: boolean = true;

  public dataSource: MatTableDataSource<DeliveryDto>;
  public displayedColumns: string[] = ['quantity', 'price', 'pricePerTon', 'realizationDate', 'userName'];

  constructor() {}

  ngAfterViewInit(): void {
    this.prepareGridData();
  }

  private prepareGridData(): void {
    if (this.warehouseMode) {
      this.displayedColumns.unshift('name');
    }

    this.dataSource = new MatTableDataSource<DeliveryDto>(this.deliveries);

    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource;
  }
}
