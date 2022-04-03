import { Component, OnInit } from '@angular/core';
import { Warehouse } from 'src/app/core/models/warehouse';

@Component({
  selector: 'app-plant-warehouse',
  templateUrl: './plant-warehouse.component.html',
  styleUrls: ['./plant-warehouse.component.scss']
})
export class PlantWarehouseComponent implements OnInit {
  public warehouses: Warehouse[] = [];
  public selectedWarehouseId: string;

  constructor() { }

  ngOnInit(): void {
  }

}
