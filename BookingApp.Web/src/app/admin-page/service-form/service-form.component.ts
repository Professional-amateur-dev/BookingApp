import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RoomService } from '../../shared/models/roomService';
import { RoomServiceService } from '../room-service-form/room-service.service';
import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-service-form',
  templateUrl: './service-form.component.html',
  styleUrls: ['./service-form.component.scss']
})
export class ServiceFormComponent implements OnInit {

  roomService: RoomService = {} as RoomService;
  modalRef: BsModalRef = {} as BsModalRef;

  constructor(
    private modalService: BsModalService,
    private toastr: ToastrService,
    private roomServiceService: RoomServiceService,
    private loadingService: LoadingService,
    private router: Router,

    ) { }

  ngOnInit(): void {
  }


}
