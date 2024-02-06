import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BidCalculationComponent } from './bid-calculation/bid-calculation.component';
import { MaterialModule } from '../material/material.module';
import { AssociationFeeModule } from '../association-fee/association-fee.module';
import { VehicleTypeModule } from '../vehicle-type/vehicle-type.module';
import { SellerSpecialFeeModule } from '../seller-special-fee/seller-special-fee.module';
import { BidCalculationService } from './bid-calculation.service';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
    declarations: [
        BidCalculationComponent
    ],
    exports: [
        BidCalculationComponent,
    ],
    imports: [
        CommonModule,
        MaterialModule,
        AssociationFeeModule,
        VehicleTypeModule,
        SellerSpecialFeeModule,
        SharedModule,
        FormsModule
    ],
    providers : [
        BidCalculationService
    ]
})
export class BidModule { }
