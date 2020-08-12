import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-service-form',
  templateUrl: './service-form.component.html',
  styleUrls: ['./service-form.component.scss']
})
export class ServiceFormComponent implements OnInit {


  constructor(private toastr: ToastrService) { }

  ngOnInit(): void {
    this.toastr.success('Hello world!', 'Toastr fun!');
  }


}
