import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  title?: string;
  seatNumbers?: Number[];
  quantity?: Number;
  totalPrice?: Number;


  constructor() { }
}
