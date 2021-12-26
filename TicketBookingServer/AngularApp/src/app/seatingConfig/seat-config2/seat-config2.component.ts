import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-seat-config2',
  templateUrl: './seat-config2.component.html',
  styleUrls: ['./seat-config2.component.css']
})
export class SeatConfig2Component implements OnInit {
  seatSelection: FormGroup;
  selectedSeats: number[];
  @Input() occupiedSeats!: number[];
  @Output() submitToParent: EventEmitter<number[]> = new EventEmitter();
  @Output() updateParent: EventEmitter<number[]> = new EventEmitter();

  constructor(private fb: FormBuilder) {
    this.selectedSeats = [];
    this.seatSelection = this.fb.group({
      1: [false],
      2: [false],
      3: [false],
      4: [false],
      5: [false],
      6: [false],
      7: [false],
      8: [false],
      9: [false],
      10: [false],
      11: [false],
      12: [false],
      13: [false],
      14: [false],
      15: [false],
      16: [false],
      17: [false],
      18: [false],
      19: [false],
      20: [false],
    });
  }

  ngOnInit(): void {
    this.seatSelection.valueChanges.subscribe(value => {
      this.selectedSeats = [];
      for (const seat in value) {
        if (value[seat]) {
          this.selectedSeats.push(parseInt(seat));
        }
      }
      this.updateParent.emit(this.selectedSeats);
    });
  }

  submit() {
    this.selectedSeats = [];
    var formVals = this.seatSelection.value;
    for (const seat in formVals) {
      if (formVals[seat]) {
        this.selectedSeats.push(parseInt(seat));
      }
    }
    this.submitToParent.emit(this.selectedSeats);
  }
}
