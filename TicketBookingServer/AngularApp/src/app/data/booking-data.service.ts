import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, tap } from 'rxjs/operators';
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookingDataService {

  constructor(private http: HttpClient) { }

  GetSelectedScreeningData(): Observable<any> {
    return this.http.get('http://localhost:33855/Booking/GetSelectedScreeningData');
  }

  GetOccupiedSeatsForScreening(): Observable<any> {
    return this.http.get('http://localhost:33855/Booking/GetOccupiedSeatsForScreening/');
  }

  PostBookingData(selectedSeats:string): Observable<any> {

    return this.http.post('http://localhost:33855/Booking/PostBookingData', selectedSeats, { headers: { 'Content-Type': 'application/json' }, responseType: 'text', observe: 'response' });
  }
}
