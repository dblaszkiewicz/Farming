import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { FertilizerState } from '../models/fertilizer';
import { FertilizerWarehouse } from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class FertilizerWarehouseService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<FertilizerWarehouse[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getAll`;
    return this.http.get<FertilizerWarehouse[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<FertilizerState[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getStatesByWarehouse?${warehouseId}`;
    return this.http.get<FertilizerState[]>(url);
  }
}
