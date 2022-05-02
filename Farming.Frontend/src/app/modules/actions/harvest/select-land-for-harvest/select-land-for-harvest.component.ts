import { Component, OnInit } from '@angular/core';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { LandStatusEnum } from 'src/app/core/models/static-types/land-status.enum';
import { HarvestActionService } from 'src/app/core/stores/harvest-action.service';

@Component({
  selector: 'app-select-land-for-harvest',
  templateUrl: './select-land-for-harvest.component.html',
  styleUrls: ['./select-land-for-harvest.component.scss'],
})
export class SelectLandForHarvestComponent implements RealizationComponentInterface, OnInit {
  constructor(private harvestActionService: HarvestActionService) {}
  public landStatusHelper = LandStatusHelper;
  public landStatusEnum = LandStatusEnum;

  public lands: LandWithPlantDto[];

  public selectedLandId: string;
  public selectedLand: LandWithPlantDto;
  public selectedMode: LandStatusEnum | null;

  async ngOnInit(): Promise<void> {
    await this.harvestActionService.prepareLands();
    this.lands = this.harvestActionService.getLands();
    this.trySetSelectedLand();
  }

  public landChange(): void {
    this.selectedLand = this.lands.find(x => x.id === this.selectedLandId)!;
    this.harvestActionService.setSelectedLand(this.selectedLand);
    this.selectedMode = null;
    this.harvestActionService.setSelectedNewLandStatus(null);
  }

  public modeChange() {
    this.harvestActionService.setSelectedNewLandStatus(this.selectedMode!);
  }

  private trySetSelectedLand(): void {
    const land = this.harvestActionService.getSelectedLand();
    if (land) {
      this.selectedLand = land!;
      this.selectedLandId = land.id;

      this.trySetSelectedNewLandStatus();
    }
  }

  private trySetSelectedNewLandStatus() {
    const newStatus = this.harvestActionService.getSelectedLandStatus();
    if (newStatus) {
      this.selectedMode = newStatus;
      this.harvestActionService.setCanGoNext(true);
    }
  }
}
