import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
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
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getNameById?warehouseId=${warehouseId}`;
    return this.http.get(url, { responseType: 'text' });
  }

  public getAll(): Observable<PesticideWarehouseDto[]> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getAll`;
    return this.http.get<PesticideWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<PesticideStateDto[]> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getStatesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<PesticideStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddPesticideDeliveryDto): Observable<void> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }

  public getDeliveriesByWarehouse(warehouseId: string): Observable<DeliveriesByPesticideWarehouseDto[]> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getDeliveriesByWarehouse?warehouseId=${warehouseId}`;
    return this.http.get<DeliveriesByPesticideWarehouseDto[]>(url);
  }

  public getDeliveriesByWarehouseAndFertilizer(
    warehouseId: string,
    pesticideId: string
  ): Observable<DeliveriesByPesticideDto> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getDeliveriesByWarehouseAndPesticide?warehouseId=${warehouseId}&pesticideId=${pesticideId}`;
    return this.http.get<DeliveriesByPesticideDto>(url);
  }
}
