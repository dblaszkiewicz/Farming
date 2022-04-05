import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { PesticideDto } from '../models/pesticide';

@Injectable({
  providedIn: 'root',
})
export class PesticideService {
  constructor(private http: HttpClient) {}

  public getAll(): Observable<PesticideDto[]> {
    const url = `${AppSettings.pesticideEndpoint}/getAll`;
    return this.http.get<PesticideDto[]>(url);
  }
}
