export interface WeatherDto {
  currentConditions: CurrentCondition;
  next_days: NextDay[];
  location: string;
  region: string;
  isEmergency: boolean;
}

export interface CurrentCondition {
  comment: string;
  day: string;
  hour: string;
  humidity: string;
  iconURL: string;
  precip: string;
  temp: Temp;
  wind: Wind;
}

export interface NextDay {
  comment: string;
  day: string;
  iconURL: string;
  max_temp: Temp;
  min_temp: Temp;
}

export interface Temp {
  c: number;
  f: number;
}

export interface Wind {
  km: number;
  mile: number;
}
