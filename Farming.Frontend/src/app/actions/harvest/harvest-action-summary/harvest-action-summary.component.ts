import { Component, OnInit } from '@angular/core';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { LandStatusEnum } from 'src/app/core/models/static-types/land-status.enum';
import { HarvestActionService } from 'src/app/core/stores/harvest-action.service';

@Component({
  selector: 'app-harvest-action-summary',
  templateUrl: './harvest-action-summary.component.html',
  styleUrls: ['./harvest-action-summary.component.scss'],
})
export class HarvestActionSummaryComponent implements RealizationComponentInterface, OnInit {
  public landStatusHelper = LandStatusHelper;
  public landStatusEnum = LandStatusEnum;
  public selectedLand: LandWithPlantDto;
  public selectedNewLandStatus: LandStatusEnum;

  constructor(private harvestActionService: HarvestActionService) {}

  ngOnInit(): void {
    this.selectedLand = this.harvestActionService.getSelectedLand()!;
    this.selectedNewLandStatus = this.harvestActionService.getSelectedLandStatus()!;
  }
}
