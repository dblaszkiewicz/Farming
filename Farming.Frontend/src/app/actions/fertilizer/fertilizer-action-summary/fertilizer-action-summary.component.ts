import { Component, OnInit } from '@angular/core';
import { FertilizerStateDto } from 'src/app/core/models/fertilizer';
import { LandDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { FertilizerWarehouseDto } from 'src/app/core/models/warehouse';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';

@Component({
  selector: 'app-fertilizer-action-summary',
  templateUrl: './fertilizer-action-summary.component.html',
  styleUrls: ['./fertilizer-action-summary.component.scss'],
})
export class FertilizerActionSummaryComponent implements RealizationComponentInterface, OnInit {
  constructor(private fertilizerActionService: FertilizerActionService) {}

  public selectedLand: LandDto;
  public selectedFertilizerState: FertilizerStateDto;
  public selectedWarehouse: FertilizerWarehouseDto;

  public requiredAmount: number;

  ngOnInit(): void {
    this.selectedLand = this.fertilizerActionService.getSelectedLand()!;
    this.selectedWarehouse = this.fertilizerActionService.getSelectedWarehouse()!;
    this.selectedFertilizerState = this.fertilizerActionService.getSelectedFertilizer()!;

    this.requiredAmount = this.selectedLand.area * this.selectedFertilizerState.requiredAmountPerHectare;
  }
}
