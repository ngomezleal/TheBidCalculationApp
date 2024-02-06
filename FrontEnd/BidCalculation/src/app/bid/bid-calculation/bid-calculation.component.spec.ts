import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BidCalculationComponent } from './bid-calculation.component';

describe('BidCalculationComponent', () => {
  let component: BidCalculationComponent;
  let fixture: ComponentFixture<BidCalculationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BidCalculationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BidCalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
