import { AfterViewInit } from '@angular/core';
import { ChangeDetectorRef } from '@angular/core';
import { OnInit } from '@angular/core';
import { Input, ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { DeliveryDto } from 'src/app/core/models/warehouse';

@Component({
  selector: 'app-display-deliveries',
  templateUrl: './display-deliveries.component.html',
  styleUrls: ['./display-deliveries.component.scss'],
})
export class DisplayDeliveriesComponent implements OnInit, AfterViewInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  @Input() public deliveries: DeliveryDto[];
  @Input() public warehouseMode: boolean = true;
  @Input() public objectType: ObjectTypeEnum;

  public objectTypeEnum = ObjectTypeEnum;
  public dataSource: MatTableDataSource<DeliveryDto>;

  public displayedColumns: string[];

  public pesticideColumns: string[] = ['quantity', 'price', 'pricePerLiter', 'realizationDate', 'userName'];

  public plantColumns: string[] = ['quantity', 'price', 'pricePerTon', 'realizationDate', 'userName'];

  public fertilizerColumns: string[] = ['quantity', 'price', 'pricePerTon', 'realizationDate', 'userName'];

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.prepareColumns();
  }

  ngAfterViewInit(): void {
    this.prepareGridData();
    this.cdr.detectChanges();
  }

  private prepareColumns(): void {
    if (this.objectType === this.objectTypeEnum.FertilizerWarehouse) {
      this.displayedColumns = this.fertilizerColumns;
    } else if (this.objectType === this.objectTypeEnum.PesticideWarehouse) {
      this.displayedColumns = this.pesticideColumns;
    } else if (this.objectType === this.objectTypeEnum.PlantWarehouse) {
      this.displayedColumns = this.plantColumns;
    }
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
