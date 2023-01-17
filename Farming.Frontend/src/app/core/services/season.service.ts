import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { SeasonDto } from '../models/season';

@Injectable({
  providedIn: 'root',
})
export class SeasonService {
  constructor(private http: HttpClient) {}

  public getCurrent(): Observable<SeasonDto> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.season}/getCurrent`;
    return this.http.get<SeasonDto>(url);
  }

  public getAll(): Observable<SeasonDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.season}/getAll`;
    return this.http.get<SeasonDto[]>(url);
  }

  public startNew(): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.season}/startNew`;
    return this.http.post<void>(url, null);
  }

  public endCurrent(): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.season}/endCurrent`;
    return this.http.put<void>(url, null);
  }
}
