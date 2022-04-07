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
  realizationDate: Date;
}

export interface DeliveryByWarehouseDto extends DeliveryDto {
  name: string;
}

export interface DeliveriesByFertilizerWarehouseDto extends DeliveryByWarehouseDto {
  pricePerTon: number;
}

export interface DeliveriesByPlantWarehouseDto extends DeliveryByWarehouseDto {
  pricePerTon: number;
}

export interface DeliveriesByPesticideWarehouseDto extends DeliveryByWarehouseDto {
  pricePerLiter: number;
}

export interface DeliveriesByObjectDto {
  deliveries: DeliveryDto[];
  name: string;
}

export interface DeliveriesByFertilizerDto extends DeliveriesByObjectDto {
  averagePricePerTon: number;
}

export interface DeliveriesByPlantDto extends DeliveriesByObjectDto {
  averagePricePerTon: number;
}

export interface DeliveriesByPesticideDto extends DeliveriesByObjectDto {
  averagePricePerLiter: number;
}
