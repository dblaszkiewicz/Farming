import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { LandDto, LandWithPlantDto } from '../models/land';

@Injectable({
  providedIn: 'root',
})
export class LandService {
  constructor(private http: HttpClient) {}

  public getAllWitPlant(): Observable<LandWithPlantDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.land}/getAllWithPlant`;
    return this.http.get<LandWithPlantDto[]>(url);
  }

  public getAll(): Observable<LandDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.land}/getAll`;
    return this.http.get<LandDto[]>(url);
  }

  public harvest(landId: string): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.land}/harvest?landId=${landId}`;
    return this.http.put<void>(url, null);
  }

  public destroy(landId: string): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.land}/destroy?landId=${landId}`;
    return this.http.put<void>(url, null);
  }
}
