import { Component, OnInit } from '@angular/core';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PesticideActionService } from 'src/app/core/stores/pesticide-action-service';

@Component({
  selector: 'app-select-land-for-pesticide',
  templateUrl: './select-land-for-pesticide.component.html',
  styleUrls: ['./select-land-for-pesticide.component.scss'],
})
export class SelectLandForPesticideComponent implements RealizationComponentInterface, OnInit {
  constructor(private pesticideActionService: PesticideActionService) {}
  public landStatusHelper = LandStatusHelper;
  public lands: LandDto[];

  public selectedLandId: string;
  public selectedLand: LandDto;

  async ngOnInit(): Promise<void> {
    await this.pesticideActionService.prepareLands();
    this.lands = this.pesticideActionService.getLands();
    this.trySetSelectedLand();
  }

  public trySetSelectedLand(): void {
    const land = this.pesticideActionService.getSelectedLand();
    if (land) {
      this.selectedLand = land!;
      this.selectedLandId = land.id;
      this.pesticideActionService.setCanGoNext(true);
    }
  }

  public landChange(): void {
    this.selectedLand = this.lands.find(x => x.id === this.selectedLandId)!;
    this.pesticideActionService.setSelectedLand(this.selectedLand);
  }
}
