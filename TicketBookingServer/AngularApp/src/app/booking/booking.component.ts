import { Component, Input, OnInit } from '@angular/core';
import { mergeMap } from 'rxjs/operators';
import { Data, Router } from '@angular/router';
import { BookingDataService } from '../data/booking-data.service';
import { ScreeningData } from '../dataModels/screening-data';
import { firstValueFrom, lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  screeningData!: ScreeningData;
  unavailableSeats: number[];
  selectedSeats: number[];
  numOfSeats!: number;

  constructor(private bookingDataService: BookingDataService, private router: Router) {
    this.unavailableSeats = [];
    this.selectedSeats = [];
  }

  ngOnInit(): void {
    this.bookingDataService.GetSelectedScreeningData().subscribe(
      result => {
        this.screeningData = result;
        this.numOfSeats = result.theatre.seatingConfig.NumberOfSeats;
      },
      error => console.log(error));

    this.bookingDataService.GetOccupiedSeatsForScreening().subscribe(
      result => this.unavailableSeats = result,
      error => console.log(error));
  }

  onUpdateParent(selectedSeats: number[]): void {
    this.selectedSeats = selectedSeats;
  }

  onSubmitToParent(selectedSeats: number[]): void {
    this.bookingDataService.PostBookingData(JSON.stringify(selectedSeats)).subscribe(
      result => this.router.navigate(['completed']),
      error => console.log(error));
  }

  public isSeatingConfig(templateId:number): boolean {
    return templateId == this.screeningData.theatre.seatingConfigId;
  }

}
