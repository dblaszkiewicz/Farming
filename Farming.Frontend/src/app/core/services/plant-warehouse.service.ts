import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
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
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<PlantWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/getAll`;
    return this.http.get<PlantWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<PlantStateDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<PlantStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddPlantDeliveryDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveriesByPlantWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveriesByPlantWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndPlant(warehouseId: string, plantId: string): Observable<DeliveriesByPlantDto> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.plantWarehouse}/getDeliveriesByWarehouseAndPlant?warehouseId=${warehouseId}&plantId=${plantId}`;
    return this.http.get<DeliveriesByPlantDto>(url);
  }
}
