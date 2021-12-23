import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BookingParams } from '../dataModels/booking-params'
import { ScreeningData } from '../dataModels/screening-data'
import { tap } from 'rxjs/operators';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class BookingDataService {

  constructor(private http: HttpClient) { }

  GetSelectedScreeningData(): Observable<any> {
    return this.http.get('http://localhost:33855/Booking/GetSelectedScreeningData').pipe(
      tap(val => console.log(val))
    );
  }

  PostBookingData(bookingParams:BookingParams): Observable<any> {

    return this.http.post('http://localhost:33855/Booking/PostBookingData', bookingParams);
  }
}
