import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BookingParams } from './booking-params'

@Injectable({
  providedIn: 'root'
})
export class BookingDataService {

  constructor(private http: HttpClient) { }

  GetSelectedScreeningData(): Observable<Object> {
    return this.http.get('http://localhost:33855/Booking/GetSelectedScreeningData', {
      headers: new HttpHeaders({
        'Access-Control-Allow-Origin': '*',
      })
    });
  }

  PostBookingData(bookingParams:BookingParams): Observable<any> {

    return this.http.post('http://localhost:33855/Booking/PostBookingData', bookingParams);
  }
}
