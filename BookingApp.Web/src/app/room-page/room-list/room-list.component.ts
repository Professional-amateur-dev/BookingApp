import { Component, OnInit } from '@angular/core';
import { RoomTypeService } from 'src/app/admin-page/room-type-form/room-type.service';
import {RoomTypeListResponse} from './room-list.response';

@Component({
  selector: 'app-room-list',
  templateUrl: './room-list.component.html',
  styleUrls: ['./room-list.component.scss']
})
export class RoomListComponent implements OnInit {

  vm: RoomTypeListResponse = { page: 1 } as RoomTypeListResponse;

  searchText?: string;

  constructor(
    private roomTypeService: RoomTypeService
  ) { }

  ngOnInit(): void {
    this.loadRoomTypes();
  }

  loadRoomTypes() {
    console.log(this.searchText);
    let params: any = { page: this.vm?.page || 1 };
    if(this.searchText) { params.search = this.searchText; }
    /*
      {
        page: 1,
        search: 'abc'
      }
    */

    this.roomTypeService
      .getRoomTypes(params)
      .subscribe(response => {
        this.vm = response;
    });
  }

}
