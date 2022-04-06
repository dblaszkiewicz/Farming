import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { FertilizerDto } from '../models/fertilizer';

@Injectable({
  providedIn: 'root',
})
export class FertilizerService {
  constructor(private http: HttpClient) {}

  public getNameById(fertilizerId: string): Observable<string> {
    const url = `${AppSettings.fertilizerEndpoint}/getNameById?fertilizerId=${fertilizerId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<FertilizerDto[]> {
    const url = `${AppSettings.fertilizerEndpoint}/getAll`;
    return this.http.get<FertilizerDto[]>(url);
  }
}
