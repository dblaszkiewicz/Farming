import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { PlantDto } from '../models/plant';

@Injectable({
  providedIn: 'root',
})
export class PlantService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PlantDto[]> {
    const url = `${AppSettings.plantEndpoint}/getAll`;
    return this.http.get<PlantDto[]>(url);
  }
}
