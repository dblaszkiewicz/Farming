import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
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
  public selectedFertilizerId: string;
  public canAddDelivery: boolean = false;

  public dataSource: MatTableDataSource<FertilizerState>;

  public displayedColumns: string[] = [
    'fertilizerTypeName',
    'fertilizerName',
    'quantity',
    'requiredAmountPerHectare',
    'enoughForArea',
    'details',
  ];

  constructor(
    private fertilizerWarehouseService: FertilizerWarehouseService,
    private fertilizerService: FertilizerService
  ) {}

  async ngOnInit(): Promise<void> {
    await this.getInitData();
  }

  public async warehouseChange(event: any): Promise<void> {
    this.selectedWarehouseId = event.id;
    await this.getWarehouseStates();
    this.prepareGridData();
  }

  public async fertilizerChange(event: any): Promise<void> {
    this.selectedFertilizerId = event.id;
    this.canAddDelivery = true;
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
    }
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<FertilizerState>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private async getFertilizers(): Promise<void> {
    this.fertilizers = await lastValueFrom(this.fertilizerService.getAll());
  }
}
