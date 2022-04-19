import { Component, OnInit } from '@angular/core';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { PlantStateDto } from 'src/app/core/models/plant';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PlantWarehouseDto } from 'src/app/core/models/warehouse';
import { PlantActionService } from 'src/app/core/stores/plant-action.service';

@Component({
  selector: 'app-plant-action-summary',
  templateUrl: './plant-action-summary.component.html',
  styleUrls: ['./plant-action-summary.component.scss'],
})
export class PlantActionSummaryComponent implements RealizationComponentInterface, OnInit {
  constructor(private plantActionService: PlantActionService) {}

  public selectedLand: LandWithPlantDto;
  public selectedPlantState: PlantStateDto;
  public selectedWarehouse: PlantWarehouseDto;
  public selectedQuantity: number;

  ngOnInit(): void {
    this.selectedLand = this.plantActionService.getSelectedLand()!;
    this.selectedWarehouse = this.plantActionService.getSelectedWarehouse()!;
    this.selectedPlantState = this.plantActionService.getSelectedPlant()!;
    this.selectedQuantity = this.plantActionService.getSelectedQuantity();
  }
}
