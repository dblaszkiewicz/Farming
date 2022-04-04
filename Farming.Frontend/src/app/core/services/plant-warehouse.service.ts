import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { Warehouse } from '../models/warehouse';

@Injectable({
  providedIn: 'root'
})
export class PlantWarehouseService {

  constructor(private http: HttpClient) { }

  public getAll(): Observable<Warehouse[]> {
    const url = `${AppSettings.plantWarehouseEndpoint}/all`;
    return this.http.get<Warehouse[]>(url)
  }
}
