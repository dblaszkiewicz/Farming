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
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}
