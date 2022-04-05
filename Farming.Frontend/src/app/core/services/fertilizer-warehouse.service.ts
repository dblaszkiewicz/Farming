import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { FertilizerStateDto } from '../models/fertilizer';
import { AddFertilizerDeliveryDto, FertilizerWarehouseDto } from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class FertilizerWarehouseService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<FertilizerWarehouseDto[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getAll`;
    return this.http.get<FertilizerWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<FertilizerStateDto[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getStatesByWarehouse?${warehouseId}`;
    return this.http.get<FertilizerStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddFertilizerDeliveryDto): Observable<void> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }
}
