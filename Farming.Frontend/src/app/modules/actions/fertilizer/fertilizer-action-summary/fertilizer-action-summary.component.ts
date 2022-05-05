import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay } from 'rxjs';
import { FertilizerStateDto } from 'src/app/core/models/fertilizer';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { FertilizerWarehouseDto } from 'src/app/core/models/warehouse';
import { FertilizerActionService } from 'src/app/core/stores/fertilizer-action.service';

@UntilDestroy()
@Component({
  selector: 'app-fertilizer-action-summary',
  templateUrl: './fertilizer-action-summary.component.html',
  styleUrls: ['./fertilizer-action-summary.component.scss'],
})
export class FertilizerActionSummaryComponent implements RealizationComponentInterface, OnInit, AfterViewInit {
  constructor(private fertilizerActionService: FertilizerActionService, private observer: BreakpointObserver) {}

  public selectedLand: LandWithPlantDto;
  public selectedFertilizerState: FertilizerStateDto;
  public selectedWarehouse: FertilizerWarehouseDto;
  public selectedQuantity: number;
  public destkopMode: boolean = true;

  ngOnInit(): void {
    this.selectedLand = this.fertilizerActionService.getSelectedLand()!;
    this.selectedWarehouse = this.fertilizerActionService.getSelectedWarehouse()!;
    this.selectedFertilizerState = this.fertilizerActionService.getSelectedFertilizer()!;
    this.selectedQuantity = this.fertilizerActionService.getSelectedQuantity();
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
