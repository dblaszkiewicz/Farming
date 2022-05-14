export interface LandDto {
  id: string;
  landClass: string;
  name: string;
  area: number;
}

export interface LandWithPlantDto extends LandDto {
  status: number;
  isPlanted: boolean;
  planted: PlantedOnLandDto;
}

export interface PlantedOnLandDto {
  plantId: string;
  plantName: string;
}

export interface LandActionDto {
  name: string;
  description: string;
  userName: string;
  quantity: number;
  realizationDate: Date;
}

export interface PesticideActionDto extends LandActionDto {}

export interface FertilizerActionDto extends LandActionDto {}

export interface PlantActionDto extends LandActionDto {}
