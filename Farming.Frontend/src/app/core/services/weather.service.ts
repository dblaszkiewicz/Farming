import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { WeatherDto } from '../models/weather';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient) {}

  public getWeather(place: string): Observable<WeatherDto> {
    const url = `${AppSettings.weatherEndpoint}/weatherByPlace?place=${encodeURIComponent(place)}`;
    return this.http.get<WeatherDto>(url);
  }
}
