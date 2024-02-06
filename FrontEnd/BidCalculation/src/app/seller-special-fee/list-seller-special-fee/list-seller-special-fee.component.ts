import { Component, Input, OnInit } from '@angular/core';
import { SellerSpecialFeeService } from '../seller-special-fee.service';

@Component({
  selector: 'app-list-seller-special-fee',
  templateUrl: './list-seller-special-fee.component.html',
  styleUrl: './list-seller-special-fee.component.css'
})
export class ListSellerSpecialFeeComponent implements OnInit {
  @Input() specialFeeId: number = 0;
  displayedColumns: string[] = ['id', 'description', 'specialFeePercentage'];

  constructor(private sellerSpecialFeeService: SellerSpecialFeeService){}

  ngOnInit(): void {
    this.sellerSpecialFeeService.listSellerSpecialFee();
  }

  get resultsSellerSpecialFee(){
    return this.sellerSpecialFeeService.respSellerSpecialFee;
  }
}