import { Component, OnInit } from '@angular/core';
import { RoomType } from '../../shared/models/roomType';
import { ActivatedRoute } from '@angular/router';
import { RoomTypeService } from 'src/app/admin-page/room-type-form/room-type.service';

@Component({
  selector: 'app-room-type-detail',
  templateUrl: './room-type-detail.component.html',
  styleUrls: ['./room-type-detail.component.scss']
})
export class RoomTypeDetailComponent implements OnInit {

  id!:number;
  roomType?: RoomType;

  constructor(
    private activatedRoute:ActivatedRoute,
    private roomTypeService: RoomTypeService
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(params => {
      this.id = Number(params.get('id'));
      this.loadRoomType();
  });
  }

  loadRoomType() {
    this.roomTypeService
      .getRoomType(this.id)
      .subscribe(result => {
        this.roomType = result;
      });
  }

}
