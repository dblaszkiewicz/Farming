import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';

@Component({
  selector: 'app-select-field',
  templateUrl: './select-field.component.html',
  styleUrls: ['./select-field.component.scss'],
})
export class SelectFieldComponent implements RealizationComponentInterface, OnInit {
  constructor(private fertilizerActionService: FertilizerActionService) {}

  public lands: LandDto[];
  public selectedLandId: string;
  public selectedLand: LandDto;
  public landStatusHelper = LandStatusHelper;

  async ngOnInit(): Promise<void> {
    await this.fertilizerActionService.prepareLands();
    await this.trySetSelectedLand();
    this.lands = this.fertilizerActionService.getLands();
  }

  public async trySetSelectedLand() {
    const land = this.fertilizerActionService.getSelectedLand();
    if (land) {
      this.selectedLand = land!;
      this.selectedLandId = land.id;
      this.fertilizerActionService.setSelectedLand(this.selectedLand);
    }
  }

  public landChange() {
    this.selectedLand = this.lands.find(x => x.id === this.selectedLandId)!;
    this.fertilizerActionService.setSelectedLand(this.selectedLand);
  }
}
