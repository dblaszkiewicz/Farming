import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { LandDto } from '../models/land';

@Injectable({
  providedIn: 'root',
})
export class LandService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<LandDto[]> {
    const url = `${AppSettings.landEndpoint}`;
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
