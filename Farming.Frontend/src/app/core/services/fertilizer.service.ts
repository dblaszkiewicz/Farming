import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { FertilizerActionDto, FertilizerDto } from '../models/fertilizer';

@Injectable({
  providedIn: 'root',
})
export class FertilizerService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<FertilizerDto[]> {
    const url = `${AppSettings.fertilizerEndpoint}/getAll`;
    return this.http.get<FertilizerDto[]>(url);
  }

  public processAction(actionDto: FertilizerActionDto): Observable<void> {
    const url = `${AppSettings.fertilizerEndpoint}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<FertilizerActionDto[]> {
    const url = `${AppSettings.fertilizerEndpoint}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<FertilizerActionDto[]>(url);
  }
}
