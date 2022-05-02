import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { PlantActionDto, PlantDto } from '../models/plant';

@Injectable({
  providedIn: 'root',
})
export class PlantService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PlantDto[]> {
    const url = `${AppSettings.plantEndpoint}/getAll`;
    return this.http.get<PlantDto[]>(url);
  }

  public processAction(actionDto: PlantActionDto): Observable<void> {
    const url = `${AppSettings.plantEndpoint}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<PlantActionDto[]> {
    const url = `${AppSettings.plantEndpoint}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<PlantActionDto[]>(url);
  }
}
