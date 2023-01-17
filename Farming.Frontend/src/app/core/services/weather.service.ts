import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { WeatherDto } from '../models/weather';

@Injectable({
  providedIn: 'root',
})
export class WeatherService {
  constructor(private http: HttpClient) {}

  public getWeather(place: string): Observable<WeatherDto> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.weather}/weatherByPlace?place=${encodeURIComponent(place)}`;
    return this.http.get<WeatherDto>(url);
  }
}
