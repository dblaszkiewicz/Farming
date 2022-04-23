import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { NextDay, WeatherDto } from 'src/app/core/models/weather';
import { SnackbarService } from 'src/app/core/services/snackbar.service';
import { WeatherService } from 'src/app/core/services/weather.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss'],
})
export class WeatherComponent implements OnInit {
  public data: WeatherDto;
  public nextDays: NextDay[];
  public canDisplay: boolean = false;
  public canGoNext: boolean = true;
  public place: string = '';

  private pageCounter: number = 1;

  constructor(
    private weatherService: WeatherService,
    private spinnerStore: SpinnerStore,
    private router: Router,
    private snackbarService: SnackbarService
  ) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getWeather('Kolosy');

    this.prepareFirstPageWeather();
    this.spinnerStore.stopSpinner();
  }

  public goBack(): void {
    if (this.pageCounter === 1) {
      this.router.navigateByUrl(`/`);
    } else {
      this.prepareFirstPageWeather();
      this.canGoNext = true;
      this.pageCounter--;
    }
  }

  public goNext(): void {
    if (this.pageCounter === 1) {
      this.prepareSecondPageWeather();
      this.pageCounter++;
      this.canGoNext = false;
    }
  }

  public async refreshWeather(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getWeather();
    this.spinnerStore.stopSpinner();
  }

  private async getWeather(firstplace?: string): Promise<void> {
    this.data = await lastValueFrom(this.weatherService.getWeather(firstplace ?? this.place));
    this.canDisplay = true;

    if (this.data.isEmergency) {
      this.snackbarService.showInfo('Nie znaleziono takiej lokalizacji');
    }

    this.place = '';
  }

  private prepareFirstPageWeather(): void {
    this.nextDays = this.data.next_days.slice(1, 4);
  }

  private prepareSecondPageWeather(): void {
    this.nextDays = this.data.next_days.slice(4, 7);
  }
}
