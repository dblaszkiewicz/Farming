import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
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
}
