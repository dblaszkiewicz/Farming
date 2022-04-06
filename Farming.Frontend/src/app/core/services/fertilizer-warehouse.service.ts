import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { FertilizerStateDto } from '../models/fertilizer';
import {
  AddFertilizerDeliveryDto,
  DeliveriesByObjectDto,
  DeliveryByWarehouseDto,
  FertilizerWarehouseDto,
} from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class FertilizerWarehouseService {
  constructor(private http: HttpClient) {}

  public getNameById(warehouseId: string): Observable<string> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<FertilizerWarehouseDto[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getAll`;
    return this.http.get<FertilizerWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<FertilizerStateDto[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<FertilizerStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddFertilizerDeliveryDto): Observable<void> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveryByWarehouseDto[]> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveryByWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndFertilizer(
    warehouseId: string,
    fertilizerId: string
  ): Observable<DeliveriesByObjectDto> {
    const url = `${AppSettings.fertilizerWarehouseEndpoint}/getDeliveriesByWarehouseAndFertilizer?warehouseId=${warehouseId}&fertilizerId=${fertilizerId}`;
    return this.http.get<DeliveriesByObjectDto>(url);
  }
}
