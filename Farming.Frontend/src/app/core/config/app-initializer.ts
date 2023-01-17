import { AppConfigService } from './app-config.service';

export function loadConfigService(appConfigService: AppConfigService): Function {
  return () => appConfigService.load();
}
