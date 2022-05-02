import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { LandDto, LandWithPlantDto } from '../models/land';

@Injectable({
  providedIn: 'root',
})
export class LandService {
  constructor(private http: HttpClient) {}

  public getAllWitPlant(): Observable<LandWithPlantDto[]> {
    const url = `${AppSettings.landEndpoint}/getAllWithPlant`;
    return this.http.get<LandWithPlantDto[]>(url);
  }

  public getAll(): Observable<LandDto[]> {
    const url = `${AppSettings.landEndpoint}/getAll`;
    return this.http.get<LandDto[]>(url);
  }

  public harvest(landId: string): Observable<void> {
    const url = `${AppSettings.landEndpoint}/harvest?landId=${landId}`;
    return this.http.put<void>(url, null);
  }

  public destroy(landId: string): Observable<void> {
    const url = `${AppSettings.landEndpoint}/destroy?landId=${landId}`;
    return this.http.put<void>(url, null);
  }
}
