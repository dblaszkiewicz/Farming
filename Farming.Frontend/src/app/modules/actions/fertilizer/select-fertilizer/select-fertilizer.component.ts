import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CustomErrorStateMatcher } from 'src/app/core/helpers/custom-error-state-matcher';
import { FertilizerStateDto } from 'src/app/core/models/fertilizer';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { FertilizerWarehouseDto } from 'src/app/core/models/warehouse';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';

@Component({
  selector: 'app-select-fertilizer',
  templateUrl: './select-fertilizer.component.html',
  styleUrls: ['./select-fertilizer.component.scss'],
})
export class SelectFertilizerComponent implements RealizationComponentInterface, OnInit {
  constructor(private fertilizerActionService: FertilizerActionService, private snackbarService: SnackbarService) {}

  public matcher = new CustomErrorStateMatcher();

  public quantityFormControl = new FormControl('', [Validators.required]);
  public selectedWarehouseId: string | null;
  public selectedFertilizerId: string | null;
  public selectedWarehouse: FertilizerWarehouseDto | null;
  public selectedFertilizer: FertilizerStateDto | null;
  public warehouses: FertilizerWarehouseDto[];
  public fertilizerStates: FertilizerStateDto[];
  public minQuantityForArea: number;
  public isEnoughQuantity: boolean = false;

  private landArea: number;

  async ngOnInit(): Promise<void> {
    this.quantityFormControl.valueChanges.subscribe(res => {
      this.fertilizerActionService.setSelectedQuantity(res);
      if (this.quantityFormControl.valid) {
        this.fertilizerActionService.setCanGoNext(true);
      } else {
        this.fertilizerActionService.setCanGoNext(false);
      }
    });

    this.landArea = this.fertilizerActionService.getSelectedLand()?.area!;
    await this.fertilizerActionService.prepareWarehouses();
    this.warehouses = this.fertilizerActionService.getWarehouses();
    await this.trySetSelectedWarehouse();
  }

  public async warehouseChange(): Promise<void> {
    this.selectedWarehouse = this.warehouses.find(x => x.id === this.selectedWarehouseId)!;
    await this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
    this.fertilizerChangeAfterWarehouseChange();
    this.fertilizerStates = this.fertilizerActionService.getFertilizerStates();
  }

  public fertilizerChange(): void {
    this.selectedFertilizer = this.fertilizerStates.find(x => x.fertilizerId === this.selectedFertilizerId)!;
    this.fertilizerActionService.setSelectedFertilizer(this.selectedFertilizer);

    this.setQuantityValidators();
  }

  private async trySetSelectedWarehouse(): Promise<void> {
    const warehouse = this.fertilizerActionService.getSelectedWarehouse();
    if (warehouse) {
      this.selectedWarehouse = warehouse!;
      this.selectedWarehouseId = warehouse.id;
      await this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.fertilizerStates = this.fertilizerActionService.getFertilizerStates();
      this.trySetSelectedFertilizer();
    } else if (this.warehouses.length === 1) {
      this.selectedWarehouse = this.warehouses[0];
      this.selectedWarehouseId = this.selectedWarehouse.id;
      await this.fertilizerActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.fertilizerStates = this.fertilizerActionService.getFertilizerStates();
      this.fertilizerActionService.setCanGoNext(false);
    } else {
      this.fertilizerActionService.setCanGoNext(false);
    }
  }

  private async trySetSelectedFertilizer(): Promise<void> {
    const fertilizer = this.fertilizerActionService.getSelectedFertilizer();

    if (fertilizer) {
      this.selectedFertilizer = fertilizer!;
      this.selectedFertilizerId = fertilizer.fertilizerId!;
      this.fertilizerActionService.setSelectedFertilizer(this.selectedFertilizer);
      this.setQuantityValidators();
    } else {
      this.fertilizerActionService.setSelectedFertilizer(null);
    }
  }

  private fertilizerChangeAfterWarehouseChange(): void {
    this.selectedFertilizer = null;
    this.selectedFertilizerId = null;
    this.fertilizerActionService.setSelectedFertilizer(null);
    this.minQuantityForArea = 0;
    this.quantityFormControl.clearValidators();
    this.quantityFormControl.setValidators(Validators.required);
    this.quantityFormControl.setValue(null);
    this.quantityFormControl.updateValueAndValidity();
  }

  private setQuantityValidators(): void {
    this.minQuantityForArea = this.selectedFertilizer?.requiredAmountPerHectare! * this.landArea;
    const maxQuantity = this.selectedFertilizer?.quantity!;
    let currentValue = 0;
    if (maxQuantity >= this.minQuantityForArea) {
      currentValue = this.minQuantityForArea;
      this.isEnoughQuantity = true;
    } else {
      this.isEnoughQuantity = false;
      this.snackbarService.showInfo('Brak wystarczającej ilości');
    }

    this.quantityFormControl.clearValidators();
    this.quantityFormControl.setValidators([
      Validators.required,
      Validators.min(this.minQuantityForArea),
      Validators.max(maxQuantity),
    ]);
    this.quantityFormControl.setValue(currentValue);
    this.quantityFormControl.updateValueAndValidity();
    this.quantityFormControl.markAsTouched();
  }
}
