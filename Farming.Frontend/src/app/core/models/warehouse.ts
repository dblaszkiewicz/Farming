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

export interface DeliveryDto {
  userName: string;
  quantity: number;
  price: number;
  pricePerTon: number;
  realizationDate: Date;
}

export interface DeliveriesByObjectDto {
  deliveries: DeliveryDto[];
  averagePricePerTon: number;
}

export interface DeliveryByWarehouseDto extends DeliveryDto {
  name: string;
}
