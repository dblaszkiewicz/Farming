import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/app/common/appsettings';
import { PlantStateDto } from '../models/plant';
import {
  AddPlantDeliveryDto,
  DeliveriesByPlantDto,
  DeliveriesByPlantWarehouseDto,
  PlantWarehouseDto,
} from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class PlantWarehouseService {
  constructor(private http: HttpClient) {}

  public getNameById(warehouseId: string): Observable<string> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

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

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveriesByPlantWarehouseDto[]> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveriesByPlantWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndPlant(warehouseId: string, plantId: string): Observable<DeliveriesByPlantDto> {
    const url = `${AppSettings.plantWarehouseEndpoint}/getDeliveriesByWarehouseAndPlant?warehouseId=${warehouseId}&plantId=${plantId}`;
    return this.http.get<DeliveriesByPlantDto>(url);
  }
}
