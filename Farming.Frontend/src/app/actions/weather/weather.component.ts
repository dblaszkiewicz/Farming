import { Component, OnInit } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { WeatherDto } from 'src/app/core/models/weather';
import { WeatherService } from 'src/app/core/services/weather.service';
import { SpinnerStore } from 'src/app/core/stores/spinner.store';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.scss'],
})
export class WeatherComponent implements OnInit {
  public data: WeatherDto;

  public canDisplay = false;

  private place = 'Kraków';

  constructor(private weatherService: WeatherService, private spinnerStore: SpinnerStore) {}

  async ngOnInit(): Promise<void> {
    this.spinnerStore.startSpinner();
    await this.getWeather();
    this.spinnerStore.stopSpinner();
    console.log('weather', this.data);
  }

  private async getWeather(): Promise<void> {
    this.data = await lastValueFrom(this.weatherService.getWeather(this.place));

    console.log('data', this.data);
    console.log(this.data.currentConditions.iconURL);

    this.canDisplay = true;
  }
}
