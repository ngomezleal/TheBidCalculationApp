import { TestBed } from '@angular/core/testing';

import { SellerSpecialFeeService } from './seller-special-fee.service';

describe('SellerSpecialFeeService', () => {
  let service: SellerSpecialFeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SellerSpecialFeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
