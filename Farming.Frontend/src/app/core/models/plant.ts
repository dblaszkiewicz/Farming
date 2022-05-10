export interface PlantDto {
  id: string;
  name: string;
  requiredAmountPerHectare: number;
  unit: string;
  description: string;
}

export interface PlantStateDto {
  plantId: string;
  plantName: string;
  quantity: number;
  unit: string;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}

export interface PlantActionDto {
  landId: string;
  plantId: string;
  plantWarehouseId: string;
  quantity: number;
}
