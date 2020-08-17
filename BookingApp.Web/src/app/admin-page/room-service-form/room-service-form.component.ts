import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RoomService } from '../../shared/models/roomService';
import { RoomServiceService } from './room-service.service';
import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-room-service-form',
  templateUrl: './room-service-form.component.html',
  styleUrls: ['./room-service-form.component.scss']
})
export class RoomServiceFormComponent implements OnInit {

  roomService: RoomService = {} as RoomService;
  modalRef: BsModalRef = {} as BsModalRef;
  roomServices?: RoomService[];

  selectedRoomService: number = 0;

  constructor(
    private roomServiceList : RoomServiceService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private roomServiceService: RoomServiceService,
    private loadingService: LoadingService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loadRoomServices();
  }

  loadRoomServices(){
    this.roomServiceList
      .getRoomServices()
      .subscribe(result => this.roomServices = result)
  }

  onChange() {
    this.roomService = this.roomServices?.find(service => service.id == this.selectedRoomService) || ({} as RoomService);
  }

  AddRoomService() {
    this.loadingService.show();
    this.roomServiceService
      .postRoomService(this.roomService)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServices();
        this.toastr.success('Success, RoomService Id: ' + result.id);
      });
  }

  UpdateRoomService() {
    this.loadingService.show();
    this.roomServiceService
      .updateRoomService(this.roomService, this.roomService.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServices();
        this.toastr.success('Success, RoomService Id: ' + result.id);
      });
  }

  DeleteRoomService() {
    this.loadingService.show();
    this.roomServiceService
      .deleteRoomService(this.roomService.id)
      .subscribe(result => {
        this.loadingService.hide();
        this.modalRef.hide();
        this.loadRoomServices();
        this.toastr.success('Success, RoomService Id: ' + this.roomService.id);
      });
  }


  openModal(form: TemplateRef<any>) {
    this.modalRef = this.modalService.show(form);
  }



}
