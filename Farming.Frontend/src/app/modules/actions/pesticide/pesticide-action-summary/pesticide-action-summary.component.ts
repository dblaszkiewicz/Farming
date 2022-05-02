import { Component, OnInit } from '@angular/core';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { PesticideStateDto } from 'src/app/core/models/pesticide';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PesticideWarehouseDto } from 'src/app/core/models/warehouse';
import { PesticideActionService } from 'src/app/core/stores/pesticide-action-service';

@Component({
  selector: 'app-pesticide-action-summary',
  templateUrl: './pesticide-action-summary.component.html',
  styleUrls: ['./pesticide-action-summary.component.scss'],
})
export class PesticideActionSummaryComponent implements RealizationComponentInterface, OnInit {
  constructor(private pesticideActionService: PesticideActionService) {}

  public selectedLand: LandWithPlantDto;
  public selectedPesticideState: PesticideStateDto;
  public selectedWarehouse: PesticideWarehouseDto;
  public selectedQuantity: number;

  ngOnInit(): void {
    this.selectedLand = this.pesticideActionService.getSelectedLand()!;
    this.selectedWarehouse = this.pesticideActionService.getSelectedWarehouse()!;
    this.selectedPesticideState = this.pesticideActionService.getSelectedPesticide()!;
    this.selectedQuantity = this.pesticideActionService.getSelectedQuantity();
  }
}
