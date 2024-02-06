import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListVehicleTypeComponent } from './list-vehicle-type/list-vehicle-type.component';
import { MaterialModule } from '../material/material.module';
import { VehicleTypeService } from './vehicle-type.service';

@NgModule({
  declarations: [
    ListVehicleTypeComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports : [
    ListVehicleTypeComponent
  ],
  providers : [
    VehicleTypeService
  ]
})
export class VehicleTypeModule { }