import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { PlantActionDto, PlantDto } from '../models/plant';

@Injectable({
  providedIn: 'root',
})
export class PlantService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PlantDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plant}/getAll`;
    return this.http.get<PlantDto[]>(url);
  }

  public processAction(actionDto: PlantActionDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plant}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<PlantActionDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plant}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<PlantActionDto[]>(url);
  }
}
