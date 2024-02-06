import { TestBed } from '@angular/core/testing';

import { BidCalculationService } from './bid-calculation.service';

describe('BidCalculationService', () => {
  let service: BidCalculationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BidCalculationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
