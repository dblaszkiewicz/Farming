import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay } from 'rxjs';
import { LandStatusHelper } from 'src/app/core/helpers/land-status-helper';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { LandStatusEnum } from 'src/app/core/models/static-types/land-status.enum';
import { HarvestActionService } from 'src/app/core/stores/harvest-action.service';

@UntilDestroy()
@Component({
  selector: 'app-harvest-action-summary',
  templateUrl: './harvest-action-summary.component.html',
  styleUrls: ['./harvest-action-summary.component.scss'],
})
export class HarvestActionSummaryComponent implements RealizationComponentInterface, OnInit, AfterViewInit {
  public landStatusHelper = LandStatusHelper;
  public landStatusEnum = LandStatusEnum;
  public selectedLand: LandWithPlantDto;
  public selectedNewLandStatus: LandStatusEnum;
  public destkopMode: boolean = true;

  constructor(private harvestActionService: HarvestActionService, private observer: BreakpointObserver) {}

  ngOnInit(): void {
    this.selectedLand = this.harvestActionService.getSelectedLand()!;
    this.selectedNewLandStatus = this.harvestActionService.getSelectedLandStatus()!;
  }

  ngAfterViewInit(): void {
    this.observer
      .observe(['(max-width: 850px)'])
      .pipe(delay(1), untilDestroyed(this))
      .subscribe(res => {
        if (res.matches) {
          this.destkopMode = false;
        } else {
          this.destkopMode = true;
        }
      });
  }
}
