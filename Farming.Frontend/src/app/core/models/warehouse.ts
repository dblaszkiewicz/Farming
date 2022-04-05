export interface Warehouse {
  id: string;
  name: string;
}

export interface PlantWarehouseDto extends Warehouse {}

export interface FertilizerWarehouseDto extends Warehouse {}

export interface PesticideWarehouseDto extends Warehouse {}

export interface AddDeliveryDto {
  price: number;
  quantity: number;
}

export interface AddFertilizerDeliveryDto extends AddDeliveryDto {
  fertilizerWarehouseId: string;
  fertilizerId: string;
}

export interface AddPesticideDeliveryDto extends AddDeliveryDto {
  pesticideWarehouseId: string;
  pesticideId: string;
}
