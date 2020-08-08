import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BookingsModule } from './bookings/bookings.module';
import { HeaderComponent } from './navigation/header/header.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatListModule } from '@angular/material/list';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { VideoQuoteComponent } from './home-page/video-quote/video-quote.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    SidenavListComponent,
    VideoQuoteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatToolbarModule,
    BookingsModule,
    MatTabsModule,
    MatIconModule,
    MatButtonModule,
    FlexLayoutModule,
    MatListModule
  ],
  exports: [
    MatToolbarModule,
    MatTabsModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    FlexLayoutModule,
    MatListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
