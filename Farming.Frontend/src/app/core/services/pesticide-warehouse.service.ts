import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { PesticideStateDto } from '../models/pesticide';
import { AddPesticideDeliveryDto, PesticideWarehouseDto } from '../models/warehouse';

@Injectable({
  providedIn: 'root',
})
export class PesticideWarehouseService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PesticideWarehouseDto[]> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getAll`;
    return this.http.get<PesticideWarehouseDto[]>(url);
  }

  public getStatesByWarehouseId(warehouseId: string): Observable<PesticideStateDto[]> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/getStatesByWarehouse?warehouse=${warehouseId}`;
    return this.http.get<PesticideStateDto[]>(url);
  }

  public addDelivery(addDeliveryDto: AddPesticideDeliveryDto): Observable<void> {
    const url = `${AppSettings.pesticideWarehouseEndpoint}/addDelivery`;
    return this.http.post<void>(url, addDeliveryDto);
  }
}
