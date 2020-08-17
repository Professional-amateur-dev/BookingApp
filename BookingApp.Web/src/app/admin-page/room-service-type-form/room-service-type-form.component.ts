import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RoomServiceType } from '../../shared/models/roomServiceType';
import { RoomServiceTypeService } from './room-service-type.service';
import { Router } from '@angular/router';
import { RoomType } from '../../shared/models/roomType';
import { RoomTypeService } from '../room-type-form/room-type.service';
import { RoomService } from '../../shared/models/roomService';
import { RoomServiceService } from '../room-service-form/room-service.service';
import { LoadingService } from '../../shared/loading/loading.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-room-service-type-form',
  templateUrl: './room-service-type-form.component.html',
  styleUrls: ['./room-service-type-form.component.scss']
})
export class RoomServiceTypeFormComponent implements OnInit {

  roomServiceType: RoomServiceType = {} as RoomServiceType;
  modalRef: BsModalRef = {} as BsModalRef;
  roomServiceTypes?: RoomServiceType[];
  //za liste roomtype i roomservice, olaksava nacin povezivanja
  roomType: RoomType = {} as RoomType;
  roomTypes?: RoomType[];
  roomService: RoomService = {} as RoomService;
  roomServices?: RoomService[];
  selectedRoomServiceType:number = 0;

  constructor(
    private roomServiceTypeList: RoomServiceTypeService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private roomServiceTypeService: RoomServiceTypeService,
    private loadingService: LoadingService,

    private roomTypeService: RoomTypeService,
    private roomTypeList: RoomTypeService,
    private roomServiceList : RoomServiceService,
    private roomServiceService: RoomServiceService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loadRoomServiceTypes();
    this.loadRoomTypes();
    this.loadRoomServices();
    
  }

  onChange() {
    if(!this.roomServiceType) { return ;}
    this.roomServiceType = this.roomServiceTypes?.find(room => room.id == this.selectedRoomServiceType) || ({} as RoomServiceType);
    
  }

  loadRoomTypes() {
    this.roomTypeList
      .getRoomTypes()
      .subscribe(result => this.roomTypes = result);
  }

  loadRoomServices(){
    this.roomServiceList
      .getRoomServices()
      .subscribe(result => this.roomServices = result)
  }

  loadRoomServiceTypes() {
    this.roomServiceTypeList
      .getRoomServiceTypes()
      .subscribe(result => this.roomServiceTypes = result);
  }

  AddRoomServiceType() {
    this.loadingService.show();
    this.roomServiceTypeService
      .postRoomServiceType(this.roomServiceType)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServiceTypes();
        this.toastr.success('Success, RoomServiceType Id: ' + result.id);
      });
  }

  UpdateRoomServiceType() {
    this.loadingService.show();
    this.roomServiceTypeService
      .updateRoomServiceType(this.roomServiceType, this.roomServiceType.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServiceTypes();
        this.toastr.success('Success, RoomServiceType Id: ' + result.id);
      });
  }

  DeleteRoomServiceType() {
    this.loadingService.show();
    this.roomServiceTypeService
      .deleteRoomServiceType(this.roomServiceType.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServiceTypes();
        this.toastr.success('Success, RoomServiceType Id: ' + this.roomServiceType.id);
      });
  }


  openModal(form: TemplateRef<any>) {
    this.modalRef = this.modalService.show(form);
  }

}
