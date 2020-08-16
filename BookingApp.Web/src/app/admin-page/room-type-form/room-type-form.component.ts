import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RoomType } from '../../shared/models/roomType';
import { RoomTypeService } from './room-type.service';
import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-room-type-form',
  templateUrl: './room-type-form.component.html',
  styleUrls: ['./room-type-form.component.scss']
})
export class RoomTypeFormComponent implements OnInit {

  roomType: RoomType = {} as RoomType;
  modalRef: BsModalRef = {} as BsModalRef;
  roomTypes?: RoomType[];

  constructor(
    private roomTypeList: RoomTypeService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private roomTypeService: RoomTypeService,
    private loadingService: LoadingService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadRoomTypes();
  }

  loadRoomTypes() {
    this.roomTypeList
      .getRoomTypes()
      .subscribe(result => this.roomTypes = result);
  }

  AddRoomType() {
    this.loadingService.show();
    this.roomTypeService
      .postRoomType(this.roomType)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomTypes();
        this.toastr.success('Success, RoomType Id: ' + result.id);
      });
  }

  UpdateRoomType() {
    this.loadingService.show();
    this.roomTypeService
      .updateRoomType(this.roomType, this.roomType.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomTypes();
        this.toastr.success('Success, RoomType Id: ' + result.id);
      });
  }

  DeleteRoomType() {
    this.loadingService.show();
    this.roomTypeService
      .deleteRoomType(this.roomType.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomTypes();
        this.toastr.success('Success, RoomType Id: ' + this.roomType.id);
      });
  }


  openModal(form: TemplateRef<any>) {
    this.modalRef = this.modalService.show(form);
  }



}
