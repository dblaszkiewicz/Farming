import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { PlantStateDto } from '../models/plant';
import { AddPlantDeliveryDto, PlantWarehouseDto } from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class PlantWarehouseService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PlantWarehouseDto[]> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getAll`;
    return this.http.get<PlantWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<PlantStateDto[]> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<PlantStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddPlantDeliveryDto): Observable<void> {
    const url = `${AppSettings.plantWarehouseEndpoint}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }
}
