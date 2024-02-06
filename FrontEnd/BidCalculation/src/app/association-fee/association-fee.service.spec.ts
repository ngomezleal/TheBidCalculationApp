import { TestBed } from '@angular/core/testing';

import { AssociationFeeService } from './association-fee.service';

describe('AssociationFeeService', () => {
  let service: AssociationFeeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AssociationFeeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
