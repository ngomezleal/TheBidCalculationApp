import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListAssociationFeeComponent } from './list-association-fee.component';

describe('ListAssociationFeeComponent', () => {
  let component: ListAssociationFeeComponent;
  let fixture: ComponentFixture<ListAssociationFeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListAssociationFeeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListAssociationFeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
