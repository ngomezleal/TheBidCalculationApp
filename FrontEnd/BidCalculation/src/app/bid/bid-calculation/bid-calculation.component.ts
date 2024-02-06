import { Component, OnInit } from '@angular/core';
import { IVehicleType } from '../../vehicle-type/interfaces/res-vehicle-type';
import { BidCalculationService } from '../bid-calculation.service';
import { IResBidCalculation } from '../interfaces/res-bid-calculation';

@Component({
  selector: 'app-bid-calculation',
  templateUrl: './bid-calculation.component.html',
  styleUrl: './bid-calculation.component.css'
})
export class BidCalculationComponent implements OnInit {
  valueVehicleTypeName: string = "";
  valueVehicleType:  number = 0;
  specialFeeId:      number = 0;
  vehicleBasePrice:  number = 0;
  basicUserFee:      number = 0;
  specialFee:        number = 0;
  associationFee:    number = 0;
  associationFeeId:  number = 0;
  fixedAmount:       number = 0;
  totalFee:          number = 0;
  show = false;

  constructor(private bidCalculationService: BidCalculationService){}

  ngOnInit(): void {
    this.bidCalculationService.subscribeOnBidCalculation().subscribe((resp : IResBidCalculation) =>{
      debugger;
      this.specialFeeId = resp.data.specialFeeId;
      this.associationFeeId = resp.data.associationFeeId;
      this.vehicleBasePrice = resp.data.vehicleBasePrice;
      this.basicUserFee = resp.data.basicUserFee;
      this.specialFee = resp.data.specialFee;
      this.associationFee = resp.data.associationFee;
      this.fixedAmount = resp.data.fixedAmount;
      this.totalFee = resp.data.totalFee;
      this.show = false;
    });
  }

  vehicleType(vType: IVehicleType){
    this.valueVehicleType = vType.id;
    this.valueVehicleTypeName = vType.name;
  }

  calculate(){
    this.show = true;
    this.bidCalculationService.bidCalculation(this.vehicleBasePrice, this.valueVehicleType);
  }
}
