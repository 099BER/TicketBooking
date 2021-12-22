import { Component, OnInit } from '@angular/core';
import { BookingDataService } from '../data/booking-data.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent implements OnInit {

  selectedScreeningData?: Object;
  constructor(private bookingDataService: BookingDataService) { }

  ngOnInit(): void {
    this.bookingDataService.GetSelectedScreeningData().subscribe(
      result => this.selectedScreeningData = result,
      error => console.log(error)/*window.location.href = 'http://localhost:33855/'*/);
  }

}
