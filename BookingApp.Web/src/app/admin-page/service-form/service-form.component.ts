import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { RoomService } from '../roomService';
import { RoomServiceService } from '../room-service.service';
import { Router } from '@angular/router';
import { LoadingService } from '../../shared/loading/loading.service';

@Component({
  selector: 'app-service-form',
  templateUrl: './service-form.component.html',
  styleUrls: ['./service-form.component.scss']
})
export class ServiceFormComponent implements OnInit {

  roomService: RoomService = {} as RoomService;

  constructor(
    private toastr: ToastrService,
    private roomServiceService: RoomServiceService,
    private loadingService: LoadingService,
    private router: Router,

    ) { }

  ngOnInit(): void {
  }

  onSubmit() {
    this.loadingService.show();
    this.roomServiceService
      .postRoomService(this.roomService)
      .subscribe(result => {
        this.loadingService.hide();
        this.toastr.success('Success' + result.id);
      });
  }

}
