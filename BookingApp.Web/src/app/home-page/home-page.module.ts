import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomePageRoutingModule } from './home-page-routing.module';
import { GalleryInfoComponent } from './gallery-info/gallery-info.component';
import { VideoQuoteComponent } from './video-quote/video-quote.component';
import { HomePageComponent } from './home-page.component';
import { FlexLayoutModule } from "@angular/flex-layout";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    GalleryInfoComponent,
    VideoQuoteComponent,
    HomePageComponent
  ],
  imports: [
    CommonModule,
    HomePageRoutingModule,
    FlexLayoutModule,
    NgbModule
  ],
  exports: [
    FlexLayoutModule
  ]
})
export class HomePageModule { }
