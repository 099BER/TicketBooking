import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatCofig1Component } from './seat-config1.component';

describe('SeatCofig1Component', () => {
  let component: SeatCofig1Component;
  let fixture: ComponentFixture<SeatCofig1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatCofig1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatCofig1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
