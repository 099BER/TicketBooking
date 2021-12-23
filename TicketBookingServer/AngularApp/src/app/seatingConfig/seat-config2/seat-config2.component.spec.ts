import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeatConfig2Component } from './seat-config2.component';

describe('SeatConfig2Component', () => {
  let component: SeatConfig2Component;
  let fixture: ComponentFixture<SeatConfig2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SeatConfig2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SeatConfig2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
