export interface Fertilizer {
  id: string;
  name: string;
  requiredAmountPerHectare: number;
  description: string;
}

export interface FertilizerState {
  fertilizerId: string;
  fertilizerTypeId: string;
  fertilizerName: string;
  fertilizerTypeName: string;
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}
