export interface FertilizerDto {
  id: string;
  name: string;
  requiredAmountPerHectare: number;
  description: string;
}

export interface FertilizerStateDto {
  fertilizerId: string;
  fertilizerTypeId: string;
  fertilizerName: string;
  fertilizerTypeName: string;
  fertilizerDescription: string;
  fertilizerTypeDescription: string;
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}

export interface FertilizerActionDto {
  landId: string;
  fertilizerId: string;
  fertilizerWarehouseId: string;
  quantity: number;
}
