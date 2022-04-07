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

  public getAll(): Observable<FertilizerDto[]> {
    const url = `${AppSettings.fertilizerEndpoint}/getAll`;
    return this.http.get<FertilizerDto[]>(url);
  }
}
