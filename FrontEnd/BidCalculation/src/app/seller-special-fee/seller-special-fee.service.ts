import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { IResSellerSpecialFee, ISellerSpecialFee } from './interfaces/res-seller-special-fee';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SellerSpecialFeeService {
  private baseUrl = environment.apiUrl;
  private sellerSpecialFeeUrl = `${this.baseUrl}/SellerSpecialFee`;
  respSellerSpecialFee: ISellerSpecialFee[]=[];

  constructor(private http: HttpClient) { }

  listSellerSpecialFee(){
    this.http.get<IResSellerSpecialFee>(this.sellerSpecialFeeUrl).subscribe(resp=>{
      this.respSellerSpecialFee = resp.data;
    });
  }

}
