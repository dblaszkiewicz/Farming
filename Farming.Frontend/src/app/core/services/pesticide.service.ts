import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { PesticideActionDto, PesticideDto } from '../models/pesticide';

@Injectable({
  providedIn: 'root',
})
export class PesticideService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PesticideDto[]> {
    const url = `${AppSettings.pesticideEndpoint}/getAll`;
    return this.http.get<PesticideDto[]>(url);
  }

  public processAction(actionDto: PesticideActionDto): Observable<void> {
    const url = `${AppSettings.pesticideEndpoint}/processAction`;
    return this.http.post<void>(url, actionDto);
  }

  public getAllActions(seasonId: string, landId: string): Observable<PesticideActionDto[]> {
    const url = `${AppSettings.pesticideEndpoint}/getAllActions?seasonId=${seasonId}&landId=${landId}`;
    return this.http.get<PesticideActionDto[]>(url);
  }
}
