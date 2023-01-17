import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiEndpointEnum } from 'src/app/core/config/api-endpoint.enum';
import { APP_CONFIG } from '../config/app-config.service';
import { AddUserDto, ChangePasswordDto, UserDto } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  public getUsers(): Observable<UserDto[]> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.user}/getAll`;
    return this.http.get<UserDto[]>(url);
  }

  public addUser(user: AddUserDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.user}/add`;
    return this.http.post<void>(url, user);
  }

  public changeActive(userId: string): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.user}/changeActive?userId=${userId}`;
    return this.http.put<void>(url, null);
  }

  public changeRole(userId: string): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.user}/changeRole?userId=${userId}`;
    return this.http.put<void>(url, null);
  }

  public changePassword(changePassword: ChangePasswordDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.user}/changePassword`;
    return this.http.put<void>(url, changePassword);
  }

  public register(user: AddUserDto): Observable<void> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.auth}/register`;
    return this.http.post<void>(url, user);
  }

  public seedSampleData(): Observable<boolean> {
    const url = `${APP_CONFIG.apiUrl}${ApiEndpointEnum.seedSampleData}`;
    return this.http.post<boolean>(url, null);
  }
}
