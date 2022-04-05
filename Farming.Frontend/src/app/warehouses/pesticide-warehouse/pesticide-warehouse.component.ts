import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { PesticideDto, PesticideStateDto } from 'src/app/core/models/pesticide';
import { AddDeliveryDto, AddPesticideDeliveryDto, PesticideWarehouseDto } from 'src/app/core/models/warehouse';
import { PesticideWarehouseService } from 'src/app/core/services/pesticide-warehouse.service';
import { PesticideService } from 'src/app/core/services/pesticide.service';
import { AddDeliveryDialogComponent } from '../common/add-delivery-dialog/add-delivery-dialog.component';

@Component({
  selector: 'app-pesticide-warehouse',
  templateUrl: './pesticide-warehouse.component.html',
  styleUrls: ['./pesticide-warehouse.component.scss'],
})
export class PesticideWarehouseComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public warehouses: PesticideWarehouseDto[];
  public pesticides: PesticideDto[];
  public states: PesticideStateDto[];
  public selectedWarehouseId: string;
  public selectedPesticideId: string | null;
  public canAddDelivery: boolean = false;

  public dataSource: MatTableDataSource<PesticideStateDto>;

  public displayedColumns: string[] = [
    'pesticideTypeName',
    'pesticideName',
    'quantity',
    'requiredAmountPerHectare',
    'enoughForArea',
    'details',
  ];

  constructor(
    private pesticideService: PesticideService,
    private pesticideWarehouseService: PesticideWarehouseService,
    private matDialog: MatDialog
  ) {}

  async ngOnInit(): Promise<void> {
    await this.getInitData();
  }

  public async warehouseChange(): Promise<void> {
    await this.getWarehouseStates();
    this.prepareGridData();
  }

  public pesticideChange() {
    if (this.selectedPesticideId) {
      this.canAddDelivery = true;
    }
  }

  public async addNewDelivery(): Promise<void> {
    const fertilizer = this.pesticides.find(x => x.id === this.selectedPesticideId);

    if (!fertilizer) {
      return;
    }

    await this.processAddDelivery(fertilizer.id, fertilizer.name);
    this.canAddDelivery = false;
    this.selectedPesticideId = null;
  }

  public async addDelivery(fertilizerId: string, fertilizerName: string) {
    await this.processAddDelivery(fertilizerId, fertilizerName);
  }

  private async processAddDelivery(pesticideId: string, pesticideName: string): Promise<void> {
    const dialogRef = this.matDialog.open(AddDeliveryDialogComponent, {
      data: { name: pesticideName },
    });

    const result = (await lastValueFrom(dialogRef.afterClosed())) as AddDeliveryDto;

    if (!result) {
      return;
    }

    const addDeliveryDto: AddPesticideDeliveryDto = {
      price: result.price,
      quantity: result.quantity,
      pesticideId: pesticideId,
      pesticideWarehouseId: this.selectedWarehouseId,
    };

    await lastValueFrom(this.pesticideWarehouseService.addDelivery(addDeliveryDto));
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
    this.warehouses = await lastValueFrom(this.pesticideWarehouseService.getAll());

    if (this.warehouses.length > 0) {
      this.selectedWarehouseId = this.warehouses[0].id;
    }
  }

  private async getWarehouseStates(): Promise<void> {
    if (this.selectedWarehouseId) {
      this.states = await lastValueFrom(
        this.pesticideWarehouseService.getStatesByWarehouseId(this.selectedWarehouseId)
      );
    }
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<PesticideStateDto>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private async getFertilizers(): Promise<void> {
    this.pesticides = await lastValueFrom(this.pesticideService.getAll());
  }
}
