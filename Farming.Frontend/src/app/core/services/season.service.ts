import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { SeasonDto } from '../models/season';

@Injectable({
  providedIn: 'root',
})
export class SeasonService {
  constructor(private http: HttpClient) {}

  public getCurrent(): Observable<SeasonDto> {
    const url = `${AppSettings.seasonEndpoint}/getCurrent`;
    return this.http.get<SeasonDto>(url);
  }

  public startNew(): Observable<void> {
    const url = `${AppSettings.seasonEndpoint}/startNew`;
    return this.http.post<void>(url, null);
  }

  public endCurrent(): Observable<void> {
    const url = `${AppSettings.seasonEndpoint}/endCurrent`;
    return this.http.put<void>(url, null);
  }
}
