export interface PesticideDto {
  id: string;
  name: string;
  requiredAmountPerHectare: number;
  description: string;
}

export interface PesticideStateDto {
  pesticideId: string;
  pesticideTypeId: string;
  pesticideName: string;
  pesticideDescription: string;
  pesticideTypeName: string;
  pesticideTypeDescription: string;
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}

export interface PesticideActionDto {
  landId: string;
  pesticideId: string;
  pesticideWarehouseId: string;
  quantity: number;
}
