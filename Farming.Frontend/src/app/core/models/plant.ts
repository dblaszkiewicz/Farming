export interface PlantDto {
  id: string;
  name: string;
  requiredAmountPerHectare: number;
  description: string;
}

export interface PlantStateDto {
  plantId: string;
  plantName: string;
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}

export interface PlantActionDto {
  landId: string;
  plantId: string;
  plantWarehouseId: string;
  quantity: number;
}
