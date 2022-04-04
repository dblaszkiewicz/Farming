import { LiveAnnouncer } from '@angular/cdk/a11y';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, Sort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { Fertilizer, FertilizerState } from 'src/app/core/models/fertilizer';
import { FertilizerWarehouse } from 'src/app/core/models/warehouse';
import { FertilizerWarehouseService } from 'src/app/core/services/fertilizer-warehouse.service';
import { FertilizerService } from 'src/app/core/services/fertilizer.service';

@Component({
  selector: 'app-fertilizer-warehouse',
  templateUrl: './fertilizer-warehouse.component.html',
  styleUrls: ['./fertilizer-warehouse.component.scss'],
})
export class FertilizerWarehouseComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public warehouses: FertilizerWarehouse[];
  public fertilizers: Fertilizer[];
  public states: FertilizerState[];
  public selectedWarehouseId: string;

  public dataSource: MatTableDataSource<FertilizerState>;

  public displayedColumns: string[] = [
    'fertilizerName',
    'fertilizerTypeName',
    'requiredAmountPerHectare',
    'quantity',
    'enoughForArea',
  ];

  constructor(
    private fertilizerWarehouseService: FertilizerWarehouseService,
    private fertilizerService: FertilizerService,
    private _liveAnnouncer: LiveAnnouncer
  ) {}

  async ngOnInit(): Promise<void> {
    await this.getInitData();
  }

  public warehouseChange(event: any): void {
    this.selectedWarehouseId = event.id;
  }

  private async getInitData(): Promise<void> {
    await this.getWarehouses();
    await this.getFertilizers();
    await this.getWarehouseStates();
    this.prepareGridData();
  }

  private async getWarehouses(): Promise<void> {
    this.warehouses = await lastValueFrom(this.fertilizerWarehouseService.getAll());

    if (this.warehouses.length > 0) {
      this.selectedWarehouseId = this.warehouses[0].id;
    }
  }

  private async getWarehouseStates(): Promise<void> {
    if (this.selectedWarehouseId) {
      this.states = await lastValueFrom(
        this.fertilizerWarehouseService.getStatesByWarehouseId(this.selectedWarehouseId)
      );
      console.log('states', this.states);
    }
  }

  private prepareGridData(): void {
    // this.paginator._intl.itemsPerPageLabel = 'Paczek na stronie';
    this.dataSource = new MatTableDataSource<FertilizerState>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  /** Announce the change in sort state for assistive technology. */
  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  private async getFertilizers(): Promise<void> {
    this.fertilizers = await lastValueFrom(this.fertilizerService.getAll());
  }
}
