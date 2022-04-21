import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CustomErrorStateMatcher } from 'src/app/core/helpers/custom-error-state-matcher';
import { PlantStateDto } from 'src/app/core/models/plant';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PlantWarehouseDto } from 'src/app/core/models/warehouse';
import { PlantActionService } from 'src/app/core/stores/plant-action.service';

@Component({
  selector: 'app-select-plant',
  templateUrl: './select-plant.component.html',
  styleUrls: ['./select-plant.component.scss'],
})
export class SelectPlantComponent implements RealizationComponentInterface, OnInit {
  constructor(private plantActionService: PlantActionService) {}

  public matcher = new CustomErrorStateMatcher();

  public quantityFormControl = new FormControl('', [Validators.required]);
  public selectedWarehouseId: string | null;
  public selectedPlantId: string | null;
  public selectedWarehouse: PlantWarehouseDto | null;
  public selectedPlant: PlantStateDto | null;
  public warehouses: PlantWarehouseDto[];
  public plantStates: PlantStateDto[];
  public minQuantityForArea: number;

  private landArea: number;

  async ngOnInit(): Promise<void> {
    this.quantityFormControl.valueChanges.subscribe(res => {
      this.plantActionService.setSelectedQuantity(res);
      if (this.quantityFormControl.valid) {
        this.plantActionService.setCanGoNext(true);
      } else {
        this.plantActionService.setCanGoNext(false);
      }
    });

    this.landArea = this.plantActionService.getSelectedLand()?.area!;
    await this.plantActionService.prepareWarehouses();
    this.warehouses = this.plantActionService.getWarehouses();
    await this.trySetSelectedWarehouse();
  }

  public async warehouseChange(): Promise<void> {
    this.selectedWarehouse = this.warehouses.find(x => x.id === this.selectedWarehouseId)!;
    await this.plantActionService.setSelectedWarehouse(this.selectedWarehouse);
    this.plantChangeAfterWarehouseChange();
    this.plantStates = this.plantActionService.getPlantStates();
  }

  public plantChange(): void {
    this.selectedPlant = this.plantStates.find(x => x.plantId === this.selectedPlantId)!;
    this.plantActionService.setSelectedPlant(this.selectedPlant);

    this.setQuantityValidators();
  }

  private async trySetSelectedWarehouse(): Promise<void> {
    const warehouse = this.plantActionService.getSelectedWarehouse();
    if (warehouse) {
      this.selectedWarehouse = warehouse!;
      this.selectedWarehouseId = warehouse.id;
      await this.plantActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.plantStates = this.plantActionService.getPlantStates();
      this.trySetSelectedPlant();
    } else if (this.warehouses.length === 1) {
      this.selectedWarehouse = this.warehouses[0];
      this.selectedWarehouseId = this.selectedWarehouse.id;
      await this.plantActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.plantStates = this.plantActionService.getPlantStates();
      this.plantActionService.setCanGoNext(false);
    } else {
      this.plantActionService.setCanGoNext(false);
    }
  }

  private async trySetSelectedPlant(): Promise<void> {
    const plant = this.plantActionService.getSelectedPlant();

    if (plant) {
      this.selectedPlant = plant!;
      this.selectedPlantId = plant.plantId!;
      this.plantActionService.setSelectedPlant(this.selectedPlant);
      this.setQuantityValidators();
    } else {
      this.plantActionService.setSelectedPlant(null);
    }
  }

  private plantChangeAfterWarehouseChange(): void {
    this.selectedPlant = null;
    this.selectedPlantId = null;
    this.plantActionService.setSelectedPlant(null);
    this.minQuantityForArea = 0;
    this.quantityFormControl.clearValidators();
    this.quantityFormControl.setValidators(Validators.required);
    this.quantityFormControl.setValue(null);
    this.quantityFormControl.updateValueAndValidity();
  }

  private setQuantityValidators(): void {
    this.minQuantityForArea = this.selectedPlant?.requiredAmountPerHectare! * this.landArea;
    const maxQuantity = this.selectedPlant?.quantity!;
    let currentValue = 0;
    if (maxQuantity >= this.minQuantityForArea) {
      currentValue = this.minQuantityForArea;
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
