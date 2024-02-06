import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VehicleTypeService } from '../vehicle-type.service';
import { FormControl } from '@angular/forms';
import { IVehicleType } from '../interfaces/res-vehicle-type';

@Component({
  selector: 'app-list-vehicle-type',
  templateUrl: './list-vehicle-type.component.html',
  styleUrl: './list-vehicle-type.component.css'
})
export class ListVehicleTypeComponent implements OnInit {
  selected: IVehicleType;
  vehicleTypeFormControl = new FormControl('');

  @Output()
  onVehicleType: EventEmitter<IVehicleType> = new EventEmitter();

  constructor(private vehicleTypeService: VehicleTypeService){
    this.selected = {
      id: 0,
      name: "",
      rangeFrom: 0,
      rangeUntil: 0
    }
  }

  ngOnInit(){
    this.vehicleTypeService.listResVehicleType();
  }

  get resultsVehicleType(){
    return this.vehicleTypeService.respVehicleType;
  }

  vehicleTypeSelected(item: IVehicleType){
    this.onVehicleType.emit(item);
  }
}