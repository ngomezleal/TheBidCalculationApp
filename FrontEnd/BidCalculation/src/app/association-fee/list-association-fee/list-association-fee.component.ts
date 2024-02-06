import { Component, Input, OnInit } from '@angular/core';
import { AssociationFeeService } from '../association-fee.service';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-list-association-fee',
  templateUrl: './list-association-fee.component.html',
  styleUrl: './list-association-fee.component.css'
})
export class ListAssociationFeeComponent implements OnInit {
  @Input() associationFeeId: number = 0;
  displayedColumns: string[] = ['id', 'description', 'rangeFrom', 'rangeUntil', 'totalAmount'];

  constructor( private associationFeeService: AssociationFeeService) {}

  ngOnInit(): void{
    this.associationFeeService.listResAssociationFee();
  }

  get resultsAssociationFee() {
    return this.associationFeeService.respAssociationFee;
  }

  get totalRows(){
    return this.associationFeeService.totalRows;
  }

  get rowsPerPage(){
    return this.associationFeeService.rowsPerPage;
  }

  onPaginatorChange(event: PageEvent){
    let page = event.pageIndex;
    let size = event.pageSize;
    page++;
    this.associationFeeService.listResAssociationFee(page, size);
  }
}

