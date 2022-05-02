import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { CustomErrorStateMatcher } from 'src/app/core/helpers/custom-error-state-matcher';
import { PesticideStateDto } from 'src/app/core/models/pesticide';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PesticideWarehouseDto } from 'src/app/core/models/warehouse';
import { PesticideActionService } from 'src/app/core/stores/pesticide-action-service';

@Component({
  selector: 'app-select-pesticide',
  templateUrl: './select-pesticide.component.html',
  styleUrls: ['./select-pesticide.component.scss'],
})
export class SelectPesticideComponent implements RealizationComponentInterface, OnInit {
  constructor(private pesticideActionService: PesticideActionService) {}

  public matcher = new CustomErrorStateMatcher();

  public quantityFormControl = new FormControl('', [Validators.required]);
  public selectedWarehouseId: string | null;
  public selectedPesticideId: string | null;
  public selectedWarehouse: PesticideWarehouseDto | null;
  public selectedPesticide: PesticideStateDto | null;
  public warehouses: PesticideWarehouseDto[];
  public pesticideStates: PesticideStateDto[];
  public minQuantityForArea: number;

  private landArea: number;

  async ngOnInit(): Promise<void> {
    this.quantityFormControl.valueChanges.subscribe(res => {
      this.pesticideActionService.setSelectedQuantity(res);
      if (this.quantityFormControl.valid) {
        this.pesticideActionService.setCanGoNext(true);
      } else {
        this.pesticideActionService.setCanGoNext(false);
      }
    });

    this.landArea = this.pesticideActionService.getSelectedLand()?.area!;
    await this.pesticideActionService.prepareWarehouses();
    this.warehouses = this.pesticideActionService.getWarehouses();
    await this.trySetSelectedWarehouse();
  }

  public async warehouseChange(): Promise<void> {
    this.selectedWarehouse = this.warehouses.find(x => x.id === this.selectedWarehouseId)!;
    await this.pesticideActionService.setSelectedWarehouse(this.selectedWarehouse);
    this.pesticideChangeAfterWarehouseChange();
    this.pesticideStates = this.pesticideActionService.getPesticideStates();
  }

  public pesticideChange(): void {
    this.selectedPesticide = this.pesticideStates.find(x => x.pesticideId === this.selectedPesticideId)!;
    this.pesticideActionService.setSelectedPesticide(this.selectedPesticide);

    this.setQuantityValidators();
  }

  private async trySetSelectedWarehouse(): Promise<void> {
    const warehouse = this.pesticideActionService.getSelectedWarehouse();
    if (warehouse) {
      this.selectedWarehouse = warehouse!;
      this.selectedWarehouseId = warehouse.id;
      await this.pesticideActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.pesticideStates = this.pesticideActionService.getPesticideStates();
      this.trySetSelectedPesticide();
    } else if (this.warehouses.length === 1) {
      this.selectedWarehouse = this.warehouses[0];
      this.selectedWarehouseId = this.selectedWarehouse.id;
      await this.pesticideActionService.setSelectedWarehouse(this.selectedWarehouse);
      this.pesticideStates = this.pesticideActionService.getPesticideStates();
      this.pesticideActionService.setCanGoNext(false);
    } else {
      this.pesticideActionService.setCanGoNext(false);
    }
  }

  private async trySetSelectedPesticide(): Promise<void> {
    const pesticide = this.pesticideActionService.getSelectedPesticide();

    if (pesticide) {
      this.selectedPesticide = pesticide!;
      this.selectedPesticideId = pesticide.pesticideId!;
      this.pesticideActionService.setSelectedPesticide(this.selectedPesticide);
      this.setQuantityValidators();
    } else {
      this.pesticideActionService.setSelectedPesticide(null);
    }
  }

  private pesticideChangeAfterWarehouseChange(): void {
    this.selectedPesticide = null;
    this.selectedPesticideId = null;
    this.pesticideActionService.setSelectedPesticide(null);
    this.minQuantityForArea = 0;
    this.quantityFormControl.clearValidators();
    this.quantityFormControl.setValidators(Validators.required);
    this.quantityFormControl.setValue(null);
    this.quantityFormControl.updateValueAndValidity();
  }

  private setQuantityValidators(): void {
    this.minQuantityForArea = this.selectedPesticide?.requiredAmountPerHectare! * this.landArea;
    const maxQuantity = this.selectedPesticide?.quantity!;
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
