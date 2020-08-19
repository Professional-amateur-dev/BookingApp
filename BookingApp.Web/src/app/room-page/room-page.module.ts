import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RoomPageRoutingModule } from './room-page-routing.module';
import { RoomListComponent } from './room-list/room-list.component';
import { RoomTypeDetailComponent } from './room-type-detail/room-type-detail.component';

import { HttpClientModule } from '@angular/common/http';
import { NgxPaginationModule } from 'ngx-pagination';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  declarations: [RoomListComponent, RoomTypeDetailComponent],
  imports: [
    CommonModule,
    RoomPageRoutingModule,
    RouterModule,
    ToastrModule.forRoot(),
    NgxPaginationModule
  ]
})
export class RoomPageModule { }
