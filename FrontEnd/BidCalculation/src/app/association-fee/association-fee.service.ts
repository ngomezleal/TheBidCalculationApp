import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { IAssociationFee, IResAssociationFee } from './interfaces/res-association-fee';

@Injectable({
  providedIn: 'root'
})
export class AssociationFeeService {

  private baseUrl: string = environment.apiUrl;
  private associationFeeUrl: string = `${this.baseUrl}/AssociationFee`
  totalRows: number = 0;
  rowsPerPage: number = 0;
  respAssociationFee: IAssociationFee[] = []

  constructor(private http: HttpClient) {}

  listResAssociationFee(page: number = 0, size: number = 3){
    const params = new HttpParams().set('page', page.toString()).set('per_page', size.toString());
    this.http.get<IResAssociationFee>(this.associationFeeUrl).subscribe(resp =>{
      this.respAssociationFee = resp.data;
      this.totalRows = 4;
      this.rowsPerPage = 2;
    })
  }
}