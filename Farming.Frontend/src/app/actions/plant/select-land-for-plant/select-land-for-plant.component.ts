import { Component, OnInit } from '@angular/core';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { PlantActionService } from 'src/app/core/stores/plant-action.service';

@Component({
  selector: 'app-select-land-for-plant',
  templateUrl: './select-land-for-plant.component.html',
  styleUrls: ['./select-land-for-plant.component.scss'],
})
export class SelectLandForPlantComponent implements RealizationComponentInterface, OnInit {
  constructor(private plantActionService: PlantActionService, private snackbarService: SnackbarService) {}
  public landStatusHelper = LandStatusHelper;
  public lands: LandDto[];

  public selectedLandId: string;
  public selectedLand: LandDto;

  async ngOnInit(): Promise<void> {
    await this.plantActionService.prepareLands();
    this.lands = this.plantActionService.getLands();
    this.trySetSelectedLand();
  }

  public trySetSelectedLand(): void {
    const land = this.plantActionService.getSelectedLand();
    if (land) {
      this.selectedLand = land!;
      this.selectedLandId = land.id;

      if (land.isPlanted) {
        this.plantActionService.setCanGoNext(false);
        this.snackbarService.showFail('Działka jest już zasiana');
      } else {
        this.plantActionService.setCanGoNext(true);
      }
    }
  }

  public landChange(): void {
    this.selectedLand = this.lands.find(x => x.id === this.selectedLandId)!;
    this.plantActionService.setSelectedLand(this.selectedLand);
  }
}
