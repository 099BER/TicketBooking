import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { BookingComponent } from './booking/booking.component';
import { CompletedComponent } from './completed/completed.component';
import { SeatConfig1Component } from './seatingConfig/seat-config1/seat-config1.component';
import { SeatConfig2Component } from './seatingConfig/seat-config2/seat-config2.component';

@NgModule({
  declarations: [
    AppComponent,
    BookingComponent,
    CompletedComponent,
    SeatConfig1Component,
    SeatConfig2Component
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: 'completed', component: CompletedComponent },
      { path: '', component: BookingComponent }]),
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
