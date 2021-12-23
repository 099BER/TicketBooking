import { Component, OnInit } from '@angular/core';
import { Data } from '@angular/router';
import { BookingDataService } from '../data/booking-data.service';
import { ScreeningData } from '../dataModels/screening-data';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  public screeningData!: ScreeningData;

  constructor(private bookingDataService: BookingDataService) { }

  ngOnInit(): void {
    this.bookingDataService.GetSelectedScreeningData().subscribe(
      result => this.screeningData = result,
      error => console.log(error));
  }

  public isSeatingConfig(templateId:number): boolean {
    return templateId == this.screeningData.theatre.seatingConfigId;
  }

}
