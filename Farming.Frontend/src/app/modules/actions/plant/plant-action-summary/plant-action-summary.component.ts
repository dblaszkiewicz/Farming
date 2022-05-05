import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay } from 'rxjs';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { PlantStateDto } from 'src/app/core/models/plant';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PlantWarehouseDto } from 'src/app/core/models/warehouse';
import { PlantActionService } from 'src/app/core/stores/plant-action.service';

@UntilDestroy()
@Component({
  selector: 'app-plant-action-summary',
  templateUrl: './plant-action-summary.component.html',
  styleUrls: ['./plant-action-summary.component.scss'],
})
export class PlantActionSummaryComponent implements RealizationComponentInterface, OnInit, AfterViewInit {
  constructor(private plantActionService: PlantActionService, private observer: BreakpointObserver) {}

  public selectedLand: LandWithPlantDto;
  public selectedPlantState: PlantStateDto;
  public selectedWarehouse: PlantWarehouseDto;
  public selectedQuantity: number;
  public destkopMode: boolean = true;

  ngOnInit(): void {
    this.selectedLand = this.plantActionService.getSelectedLand()!;
    this.selectedWarehouse = this.plantActionService.getSelectedWarehouse()!;
    this.selectedPlantState = this.plantActionService.getSelectedPlant()!;
    this.selectedQuantity = this.plantActionService.getSelectedQuantity();
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
