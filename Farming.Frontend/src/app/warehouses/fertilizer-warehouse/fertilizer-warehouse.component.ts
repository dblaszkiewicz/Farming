import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { FertilizerDto, FertilizerStateDto } from 'src/app/core/models/fertilizer';
import { AddDeliveryDto, AddFertilizerDeliveryDto, FertilizerWarehouseDto } from 'src/app/core/models/warehouse';
import { FertilizerWarehouseService } from 'src/app/core/services/fertilizer-warehouse.service';
import { FertilizerService } from 'src/app/core/services/fertilizer.service';
import { AddDeliveryDialogComponent } from '../common/add-delivery-dialog/add-delivery-dialog.component';

@Component({
  selector: 'app-fertilizer-warehouse',
  templateUrl: './fertilizer-warehouse.component.html',
  styleUrls: ['./fertilizer-warehouse.component.scss'],
})
export class FertilizerWarehouseComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public warehouses: FertilizerWarehouseDto[];
  public fertilizers: FertilizerDto[];
  public states: FertilizerStateDto[];
  public selectedWarehouseId: string;
  public selectedFertilizerId: string | null;
  public canAddDelivery: boolean = false;

  public dataSource: MatTableDataSource<FertilizerStateDto>;

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
    private fertilizerService: FertilizerService,
    private matDialog: MatDialog
  ) {}

  async ngOnInit(): Promise<void> {
    await this.getInitData();
  }

  public async warehouseChange(): Promise<void> {
    await this.getWarehouseStates();
    this.prepareGridData();
  }

  public fertilizerChange() {
    if (this.selectedFertilizerId) {
      this.canAddDelivery = true;
    }
  }

  public async addNewDelivery(): Promise<void> {
    const fertilizer = this.fertilizers.find(x => x.id === this.selectedFertilizerId);

    if (!fertilizer) {
      return;
    }

    await this.processAddDelivery(fertilizer.id, fertilizer.name);
    this.canAddDelivery = false;
    this.selectedFertilizerId = null;
  }

  public async addDelivery(fertilizerId: string, fertilizerName: string) {
    await this.processAddDelivery(fertilizerId, fertilizerName);
  }

  private async processAddDelivery(fertilizerId: string, fertilizerName: string): Promise<void> {
    const dialogRef = this.matDialog.open(AddDeliveryDialogComponent, {
      data: { name: fertilizerName },
    });

    const result = (await lastValueFrom(dialogRef.afterClosed())) as AddDeliveryDto;

    if (!result) {
      return;
    }

    const addDeliveryDto: AddFertilizerDeliveryDto = {
      price: result.price,
      quantity: result.quantity,
      fertilizerId: fertilizerId,
      fertilizerWarehouseId: this.selectedWarehouseId,
    };

    await lastValueFrom(this.fertilizerWarehouseService.addDelivery(addDeliveryDto));
    await this.getWarehouseStates();
    this.prepareGridData();
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
    this.dataSource = new MatTableDataSource<FertilizerStateDto>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private async getFertilizers(): Promise<void> {
    this.fertilizers = await lastValueFrom(this.fertilizerService.getAll());
  }
}
