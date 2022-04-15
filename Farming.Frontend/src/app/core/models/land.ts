export interface LandDto {
  id: string;
  landClass: string;
  name: string;
  area: number;
  status: number;
  isPlanted: boolean;
  planted: PlantedOnLandDto;
}

export interface PlantedOnLandDto {
  plantId: string;
  plantName: string;
}
