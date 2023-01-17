import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { PesticideActionDto, PesticideDto } from '../models/pesticide';

@Injectable({
  providedIn: 'root',
})
export class PesticideService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PesticideDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticide}/getAll`;
    return this.http.get<PesticideDto[]>(url);
  }

  public processAction(actionDto: PesticideActionDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticide}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<PesticideActionDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticide}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<PesticideActionDto[]>(url);
  }
}
