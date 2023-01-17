import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { PesticideStateDto } from '../models/pesticide';
import {
  AddPesticideDeliveryDto,
  DeliveriesByPesticideDto,
  DeliveriesByPesticideWarehouseDto,
  PesticideWarehouseDto,
} from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class PesticideWarehouseService {
  constructor(private http: HttpClient) {}

  public getNameById(warehouseId: string): Observable<string> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<PesticideWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getAll`;
    return this.http.get<PesticideWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<PesticideStateDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<PesticideStateDto[]>(url);
  }

  public getStatesByWarehouseAndPlantId(warehouseId: string, plantId: string): Observable<PesticideStateDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getStatesByWarehouseAndPlant?warehouseId=${warehouseId}&plantId=${plantId}`;
    return this.http.get<PesticideStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddPesticideDeliveryDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveriesByPesticideWarehouseDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveriesByPesticideWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndFertilizer(
    warehouseId: string,
    pesticideId: string
  ): Observable<DeliveriesByPesticideDto> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.pesticideWarehouse}/getDeliveriesByWarehouseAndPesticide?warehouseId=${warehouseId}&pesticideId=${pesticideId}`;
    return this.http.get<DeliveriesByPesticideDto>(url);
  }
}
