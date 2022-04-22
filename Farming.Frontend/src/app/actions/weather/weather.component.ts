import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { lastValueFrom } from 'rxjs';
import { NextDay, WeatherDto } from 'src/app/core/models/weather';
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

  private pageCounter: number = 1;

  private place = 'Kraków';

  constructor(private weatherService: WeatherService, private spinnerStore: SpinnerStore, private router: Router) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getWeather();

    this.prepareFirstPageWeather();
    this.spinnerStore.stopSpinner();
  }

  public goBack() {
    if (this.pageCounter === 1) {
      this.router.navigateByUrl(`/`);
    } else {
      this.prepareFirstPageWeather();
      this.canGoNext = true;
      this.pageCounter--;
    }
  }

  public goNext() {
    if (this.pageCounter === 1) {
      this.prepareSecondPageWeather();
      this.pageCounter++;
      this.canGoNext = false;
    }
  }

  private async getWeather(): Promise<void> {
    this.data = await lastValueFrom(this.weatherService.getWeather(this.place));
    console.log('Data', this.data);
    this.canDisplay = true;
  }

  private prepareFirstPageWeather() {
    this.nextDays = this.data.next_days.slice(1, 4);
  }

  private prepareSecondPageWeather() {
    this.nextDays = this.data.next_days.slice(4, 7);
  }
}
