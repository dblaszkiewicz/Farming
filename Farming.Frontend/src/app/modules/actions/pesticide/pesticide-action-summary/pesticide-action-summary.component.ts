import { BreakpointObserver } from '@angular/cdk/layout';
import { AfterViewInit, Component, OnInit } from '@angular/core';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { delay } from 'rxjs';
import { LandWithPlantDto } from 'src/app/core/models/land';
import { PesticideStateDto } from 'src/app/core/models/pesticide';
import { RealizationComponentInterface } from 'src/app/core/models/realization';
import { PesticideWarehouseDto } from 'src/app/core/models/warehouse';
import { PesticideActionService } from 'src/app/core/stores/pesticide-action-service';

@UntilDestroy()
@Component({
  selector: 'app-pesticide-action-summary',
  templateUrl: './pesticide-action-summary.component.html',
  styleUrls: ['./pesticide-action-summary.component.scss'],
})
export class PesticideActionSummaryComponent implements RealizationComponentInterface, OnInit, AfterViewInit {
  constructor(private pesticideActionService: PesticideActionService, private observer: BreakpointObserver) {}

  public selectedLand: LandWithPlantDto;
  public selectedPesticideState: PesticideStateDto;
  public selectedWarehouse: PesticideWarehouseDto;
  public selectedQuantity: number;
  public destkopMode: boolean = true;

  ngOnInit(): void {
    this.selectedLand = this.pesticideActionService.getSelectedLand()!;
    this.selectedWarehouse = this.pesticideActionService.getSelectedWarehouse()!;
    this.selectedPesticideState = this.pesticideActionService.getSelectedPesticide()!;
    this.selectedQuantity = this.pesticideActionService.getSelectedQuantity();
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
