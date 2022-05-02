import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { PesticideDto, PesticideStateDto } from 'src/app/core/models/pesticide';
import { AddDeliveryDto, AddPesticideDeliveryDto, PesticideWarehouseDto } from 'src/app/core/models/warehouse';
import { PesticideWarehouseService } from 'src/app/core/services/pesticide-warehouse.service';
import { PesticideService } from 'src/app/core/services/pesticide.service';
import { AddDeliveryDialogComponent } from '../../common/add-delivery-dialog/add-delivery-dialog.component';
import { Location } from '@angular/common';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';
import { SnackbarService } from 'src/app/core/services/snackbar.service';

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
  public selectedWarehouseId: string | null;
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
    private matDialog: MatDialog,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    private spinnerStore: SpinnerStore,
    private snackbarService: SnackbarService
  ) {
    this.selectedWarehouseId = this.route.snapshot.paramMap.get('id');
  }

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getInitData();
    this.spinnerStore.stopSpinner();
  }

  public async warehouseChange(): Promise<void> {
    this.spinnerStore.startSpinner();
    this.replaceUrl();
    await this.getWarehouseStates();
    this.spinnerStore.stopSpinner();
  }

  public goToDeliveries(): void {
    this.router.navigateByUrl(`/warehouse/pesticide/delivery/${this.selectedWarehouseId}`);
  }

  public goToDeliveriesByPesticide(pesticideId: string): void {
    this.router.navigateByUrl(`/warehouse/pesticide/delivery/${this.selectedWarehouseId}/${pesticideId}`);
  }

  public pesticideChange() {
    if (this.selectedPesticideId) {
      this.canAddDelivery = true;
    }
  }

  public async addNewDelivery(): Promise<void> {
    const pesticide = this.pesticides.find(x => x.id === this.selectedPesticideId);

    if (!pesticide) {
      return;
    }

    await this.processAddDelivery(pesticide.id, pesticide.name);
    this.canAddDelivery = false;
    this.selectedPesticideId = null;
  }

  public async addDelivery(pesticideId: string, pesticideName: string) {
    await this.processAddDelivery(pesticideId, pesticideName);
  }

  private async processAddDelivery(pesticideId: string, pesticideName: string): Promise<void> {
    const dialogRef = this.matDialog.open(AddDeliveryDialogComponent, {
      data: { name: pesticideName, objectType: ObjectTypeEnum.PesticideWarehouse },
    });

    const result = (await lastValueFrom(dialogRef.afterClosed())) as AddDeliveryDto;

    if (!result) {
      return;
    }

    const addDeliveryDto: AddPesticideDeliveryDto = {
      price: result.price,
      quantity: result.quantity,
      pesticideId: pesticideId,
      pesticideWarehouseId: this.selectedWarehouseId!,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.pesticideWarehouseService.addDelivery(addDeliveryDto));
    await this.getWarehouseStates();
    this.snackbarService.showSuccess('Pomyślnie dodano dostawę');
    this.spinnerStore.stopSpinner();
  }

  private async getInitData(): Promise<void> {
    await this.getWarehouses();
    await this.getPesticides();
    await this.getWarehouseStates();
  }

  private async getWarehouses(): Promise<void> {
    this.warehouses = await lastValueFrom(this.pesticideWarehouseService.getAll());

    if (!this.selectedWarehouseId && this.warehouses.length > 0) {
      this.selectedWarehouseId = this.warehouses[0].id;
      this.replaceUrl();
    }
  }

  private async getWarehouseStates(): Promise<void> {
    if (this.selectedWarehouseId) {
      this.states = await lastValueFrom(
        this.pesticideWarehouseService.getStatesByWarehouseId(this.selectedWarehouseId)
      );
      this.prepareGridData();
    }
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<PesticideStateDto>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private async getPesticides(): Promise<void> {
    this.pesticides = await lastValueFrom(this.pesticideService.getAll());
  }

  private replaceUrl(): void {
    this.location.replaceState(`/warehouse/pesticide/${this.selectedWarehouseId}`);
  }
}
