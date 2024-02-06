import { EventEmitter, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { IResBidCalculation, IBidCalculation } from './interfaces/res-bid-calculation';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BidCalculationService {
  private baseUrl = environment.apiUrl;
  private bidCalculationUrl = `${this.baseUrl}/BidCalculation`
  onBidCalculationChange: EventEmitter<IResBidCalculation> = new EventEmitter();

  constructor(private http: HttpClient) {
  }

  bidCalculation(basePrice: number, vehicleTypeId: number){
    //const params = new HttpParams().set('basePrice', basePrice.toString()).set('vehicleTypeId', vehicleTypeId.toString());
    let url = `${this.bidCalculationUrl}/${basePrice}/${vehicleTypeId}`
    this.http.get<IResBidCalculation>(url).subscribe(resp=>{
      this.emitOnBidCalculationChange(resp);
    });
  }

  emitOnBidCalculationChange(value: IResBidCalculation) {
    this.onBidCalculationChange.emit(value);
  }

  subscribeOnBidCalculation() {
    return this.onBidCalculationChange;
  }
}