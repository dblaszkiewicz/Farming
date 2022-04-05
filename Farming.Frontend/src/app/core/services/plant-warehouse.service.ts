import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { PlantWarehouseDto } from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class PlantWarehouseService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PlantWarehouseDto[]> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getAll`;
    return this.http.get<PlantWarehouseDto[]>(url);
  }
}
