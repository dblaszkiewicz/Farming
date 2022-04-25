import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppSettings } from 'src/common/appsettings';
import { AddUserDto, UserDto } from '../models/user';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private http: HttpClient) {}

  public getUsers(): Observable<UserDto[]> {
    const url = `${AppSettings.userEndpoint}/getAll`;
    return this.http.get<UserDto[]>(url);
  }

  public addUser(user: AddUserDto): Observable<void> {
    const url = `${AppSettings.userEndpoint}/add`;
    return this.http.post<void>(url, user);
  }

  public changeActive(userId: string): Observable<void> {
    const url = `${AppSettings.userEndpoint}/changeActive?userId=${userId}`;
    return this.http.put<void>(url, null);
  }

  public changeRole(userId: string): Observable<void> {
    const url = `${AppSettings.userEndpoint}/changeRole?userId=${userId}`;
    return this.http.put<void>(url, null);
  }
}
