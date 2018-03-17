import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { DemoScheduleComponent } from './demo-schedule/demo-schedule.component';


@NgModule({
  declarations: [
    AppComponent,
    DemoScheduleComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
