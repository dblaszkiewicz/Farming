import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { FertilizerStateDto } from '../models/fertilizer';
import {
  AddFertilizerDeliveryDto,
  DeliveriesByFertilizerDto,
  DeliveriesByFertilizerWarehouseDto,
  FertilizerWarehouseDto,
} from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class FertilizerWarehouseService {
  constructor(private http: HttpClient) {}

  public getNameById(warehouseId: string): Observable<string> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<FertilizerWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getAll`;
    return this.http.get<FertilizerWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<FertilizerStateDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<FertilizerStateDto[]>(url);
  }

  public getStatesByWarehouseAndPlantId(warehouseId: string, plantId: string): Observable<FertilizerStateDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getStatesByWarehouseAndPlant?warehouseId=${warehouseId}&plantId=${plantId}`;
    return this.http.get<FertilizerStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddFertilizerDeliveryDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveriesByFertilizerWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveriesByFertilizerWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndFertilizer(
    warehouseId: string,
    fertilizerId: string
  ): Observable<DeliveriesByFertilizerDto> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.fertilizerWarehouse}/getDeliveriesByWarehouseAndFertilizer?warehouseId=${warehouseId}&fertilizerId=${fertilizerId}`;
    return this.http.get<DeliveriesByFertilizerDto>(url);
  }
}
