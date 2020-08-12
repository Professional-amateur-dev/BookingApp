import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { GalleryInfoComponent } from './gallery-info/gallery-info.component';
import { VideoQuoteComponent } from './video-quote/video-quote.component';
import { HomePageComponent } from './home-page.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RoomsComponent } from './rooms/rooms.component';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { FlexLayoutModule } from "@angular/flex-layout";
import {MatCardModule} from '@angular/material/card';
import { CarouselModule } from 'ngx-bootstrap/carousel';


@NgModule({
  declarations: [
    GalleryInfoComponent,
    VideoQuoteComponent,
    HomePageComponent,
    RoomsComponent
  ],
  imports: [
    CommonModule,
    HomePageRoutingModule,
    FlexLayoutModule,
    NgbModule,
    MatIconModule,
    MatButtonModule,
    MatCardModule,
    CarouselModule
  ],
  exports: [
    FlexLayoutModule
  ]
})
export class HomePageModule { }
