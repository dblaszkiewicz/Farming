import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AppConfig } from './app-config';

export let APP_CONFIG: AppConfig;

@Injectable()
export class AppConfigService {
  constructor(private httpClient: HttpClient) {}

  public async load() {
    APP_CONFIG = Object.assign(
      new AppConfig(),
      await lastValueFrom(this.httpClient.get(`/assets/config/${environment.name}.json`))
    );
  }
}
