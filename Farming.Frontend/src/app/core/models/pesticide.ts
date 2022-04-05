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
  pesticideTypeName: string;
  quantity: number;
  requiredAmountPerHectare: number;
  enoughForArea: number;
}
