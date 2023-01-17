import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { FertilizerActionDto, FertilizerDto } from '../models/fertilizer';

@Injectable({
  providedIn: 'root',
})
export class FertilizerService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<FertilizerDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizer}/getAll`;
    return this.http.get<FertilizerDto[]>(url);
  }

  public processAction(actionDto: FertilizerActionDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizer}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<FertilizerActionDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizer}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<FertilizerActionDto[]>(url);
  }
}
