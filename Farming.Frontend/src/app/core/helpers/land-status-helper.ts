import { LandStatusEnum } from '../models/static-types/land-status.enum';

export class LandStatusHelper {
  static getStatusName(status: number): string {
    if (status === LandStatusEnum.Planted) {
      return 'Zasiane';
    }

    if (status === LandStatusEnum.Harvested) {
      return 'Zebrane';
    }

    if (status === LandStatusEnum.Destroyed) {
      return 'Zniszczone';
    }

    return 'Nieznane';
  }
}
