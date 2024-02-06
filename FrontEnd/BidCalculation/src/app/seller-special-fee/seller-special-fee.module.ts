import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListSellerSpecialFeeComponent } from './list-seller-special-fee/list-seller-special-fee.component';
import { SellerSpecialFeeService } from './seller-special-fee.service';
import { MaterialModule } from '../material/material.module';



@NgModule({
  declarations: [
    ListSellerSpecialFeeComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ],
  exports: [
    ListSellerSpecialFeeComponent
  ],
  providers: [
    SellerSpecialFeeService
  ]
})
export class SellerSpecialFeeModule { }
