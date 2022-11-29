import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { lastValueFrom } from 'rxjs';
import { LandDto } from 'src/app/core/models/land';
import { SeasonDto } from 'src/app/core/models/season';
import { FertilizerService } from 'src/app/core/services/fertilizer.service';
import { LandService } from 'src/app/core/services/land.service';
import { PesticideService } from 'src/app/core/services/pesticide.service';
import { PlantService } from 'src/app/core/services/plant.service';
import { SeasonService } from 'src/app/core/services/season.service';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';
import { ActionsPreviewDialogComponent } from '../actions-preview-dialog/actions-preview-dialog.component';

@Component({
  selector: 'app-lands-preview',
  templateUrl: './lands-preview.component.html',
  styleUrls: ['./lands-preview.component.scss'],
})
export class LandsPreviewComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public lands: LandDto[];
  public seasons: SeasonDto[];
  public selectedSeasonId: string;
  public dataSource: MatTableDataSource<LandDto>;

  public canGoToDetails: boolean = false;

  public displayedColumns: string[] = [
    'name',
    'landClass',
    'area',
    'plantActions',
    'fertilizerActions',
    'pesticideActions',
  ];

  constructor(
    private spinnerStore: SpinnerStore,
    private seasonService: SeasonService,
    private landService: LandService,
    private matDialog: MatDialog,
    private plantService: PlantService,
    private pesticideService: PesticideService,
    private fertilizerService: FertilizerService,
    private snackbarService: SnackbarService
  ) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getInitData();
    this.prepareGridData();
    this.spinnerStore.stopSpinner();
  }

  public async seasonChange(): Promise<void> {
    this.canGoToDetails = true;
  }

  public async getPlantActions(plantId: string): Promise<void> {
    this.spinnerStore.startSpinner();
    const actions = await lastValueFrom(this.plantService.getAllActions(this.selectedSeasonId, plantId));
    this.spinnerStore.stopSpinner();

    if (actions.length > 0) {
      this.matDialog.open(ActionsPreviewDialogComponent, {
        data: actions,
      });
    } else {
      await this.snackbarService.showInfo('LandsPreview.NoActions');
    }
  }

  public async getPesticideActions(plantId: string): Promise<void> {
    this.spinnerStore.startSpinner();
    const actions = await lastValueFrom(this.pesticideService.getAllActions(this.selectedSeasonId, plantId));
    this.spinnerStore.stopSpinner();

    if (actions.length > 0) {
      this.matDialog.open(ActionsPreviewDialogComponent, {
        data: actions,
      });
    } else {
      await this.snackbarService.showInfo('LandsPreview.NoActions');
    }
  }

  public async getFertilizerActions(plantId: string): Promise<void> {
    this.spinnerStore.startSpinner();
    const actions = await lastValueFrom(this.fertilizerService.getAllActions(this.selectedSeasonId, plantId));
    this.spinnerStore.stopSpinner();

    if (actions.length > 0) {
      this.matDialog.open(ActionsPreviewDialogComponent, {
        data: actions,
      });
    } else {
      await this.snackbarService.showInfo('LandsPreview.NoActions');
    }
  }

  private async getInitData(): Promise<void> {
    this.lands = await lastValueFrom(this.landService.getAll());
    this.seasons = await lastValueFrom(this.seasonService.getAll());
  }

  private prepareGridData(): void {
    this.paginator._intl.itemsPerPageLabel = 'Rekordów na stronie';
    this.dataSource = new MatTableDataSource<LandDto>(this.lands);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }
}
