import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListSellerSpecialFeeComponent } from './list-seller-special-fee.component';

describe('ListSellerSpecialFeeComponent', () => {
  let component: ListSellerSpecialFeeComponent;
  let fixture: ComponentFixture<ListSellerSpecialFeeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListSellerSpecialFeeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ListSellerSpecialFeeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
