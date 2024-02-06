import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { IResVehicleType, IVehicleType } from './interfaces/res-vehicle-type';

@Injectable({
  providedIn: 'root'
})
export class VehicleTypeService {
  private baseUrl: string = environment.apiUrl;
  private vehicleTypeUrl = `${this.baseUrl}/VehicleTypes`
  respVehicleType: IVehicleType[] = [];

  constructor(private http: HttpClient) { }

  listResVehicleType(){
    this.http.get<IResVehicleType>(this.vehicleTypeUrl).subscribe(resp=>{
      this.respVehicleType = resp.data
    });
  }
}