import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListAssociationFeeComponent } from './list-association-fee/list-association-fee.component';
import { AssociationFeeService } from './association-fee.service';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [
    ListAssociationFeeComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    ListAssociationFeeComponent
  ],
  providers: [
    AssociationFeeService
  ]
})
export class AssociationFeeModule { }