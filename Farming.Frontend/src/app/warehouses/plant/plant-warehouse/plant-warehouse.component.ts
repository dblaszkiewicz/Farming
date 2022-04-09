import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { PlantDto, PlantStateDto } from 'src/app/core/models/plant';
import { AddDeliveryDto, AddPlantDeliveryDto, PlantWarehouseDto } from 'src/app/core/models/warehouse';
import { PlantWarehouseService } from 'src/app/core/services/plant-warehouse.service';
import { PlantService } from 'src/app/core/services/plant.service';
import { Location } from '@angular/common';
import { AddDeliveryDialogComponent } from '../../common/add-delivery-dialog/add-delivery-dialog.component';
import { ObjectTypeEnum } from 'src/app/core/models/static-types/object-type.enum';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';
import { SnackbarService } from 'src/app/core/services/snackbar.service';

@Component({
  selector: 'app-plant-warehouse',
  templateUrl: './plant-warehouse.component.html',
  styleUrls: ['./plant-warehouse.component.scss'],
})
export class PlantWarehouseComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public warehouses: PlantWarehouseDto[] = [];
  public plants: PlantDto[];
  public states: PlantStateDto[];
  public selectedWarehouseId: string | null;
  public selectedPlantId: string | null;
  public canAddDelivery: boolean = false;

  public dataSource: MatTableDataSource<PlantStateDto>;

  public displayedColumns: string[] = ['plantName', 'quantity', 'requiredAmountPerHectare', 'enoughForArea', 'actions'];

  constructor(
    private plantWarehouseService: PlantWarehouseService,
    private plantService: PlantService,
    private matDialog: MatDialog,
    private location: Location,
    private route: ActivatedRoute,
    private router: Router,
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

  public plantChange(): void {
    if (this.selectedPlantId) {
      this.canAddDelivery = true;
    }
  }

  public async addNewDelivery(): Promise<void> {
    const plant = this.plants.find(x => x.id === this.selectedPlantId);

    if (!plant) {
      return;
    }

    await this.processAddDelivery(plant.id, plant.name);
    this.canAddDelivery = false;
    this.selectedPlantId = null;
  }

  public async addDelivery(plantId: string, plantName: string): Promise<void> {
    await this.processAddDelivery(plantId, plantName);
  }

  public goToDeliveries() {
    this.router.navigateByUrl(`/warehouse/plant/delivery/${this.selectedWarehouseId}`);
  }

  public goToDeliveriesByPlant(plantId: string): void {
    this.router.navigateByUrl(`/warehouse/plant/delivery/${this.selectedWarehouseId}/${plantId}`);
  }

  private async getInitData(): Promise<void> {
    await this.getWarehouses();
    await this.getPlants();
    await this.getWarehouseStates();
  }

  private async processAddDelivery(plantId: string, plantName: string): Promise<void> {
    const dialogRef = this.matDialog.open(AddDeliveryDialogComponent, {
      data: { name: plantName, objectType: ObjectTypeEnum.PlantWarehouse },
    });

    const result = (await lastValueFrom(dialogRef.afterClosed())) as AddDeliveryDto;

    if (!result) {
      return;
    }

    const addDeliveryDto: AddPlantDeliveryDto = {
      price: result.price,
      quantity: result.quantity,
      plantId: plantId,
      plantWarehouseId: this.selectedWarehouseId!,
    };

    this.spinnerStore.startSpinner();
    await lastValueFrom(this.plantWarehouseService.addDelivery(addDeliveryDto));
    await this.getWarehouseStates();
    this.snackbarService.showSuccess('Pomyślnie dodano dostawę');
    this.spinnerStore.stopSpinner();
  }

  private async getWarehouses(): Promise<void> {
    this.warehouses = await lastValueFrom(this.plantWarehouseService.getAll());

    if (!this.selectedWarehouseId && this.warehouses.length > 0) {
      this.selectedWarehouseId = this.warehouses[0].id;
      this.replaceUrl();
    }
  }

  private async getWarehouseStates(): Promise<void> {
    if (this.selectedWarehouseId) {
      this.states = await lastValueFrom(this.plantWarehouseService.getStatesByWarehouseId(this.selectedWarehouseId));
    }
    this.prepareGridData();
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<PlantStateDto>(this.states);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private async getPlants(): Promise<void> {
    this.plants = await lastValueFrom(this.plantService.getAll());
  }

  private replaceUrl(): void {
    this.location.replaceState(`/warehouse/plant/${this.selectedWarehouseId}`);
  }
}
