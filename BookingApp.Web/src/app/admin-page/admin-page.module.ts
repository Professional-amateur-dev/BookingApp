import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { AdminPageRoutingModule } from './admin-page-routing.module';
import { ServiceFormComponent } from './service-form/service-form.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RoomServiceFormComponent } from './room-service-form/room-service-form.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';

@NgModule({
  declarations: [ServiceFormComponent, RoomServiceFormComponent],
  imports: [
    RouterModule,
    CommonModule,
    AdminPageRoutingModule,
    NgbModule,
    FormsModule,
    HttpClientModule,
    AccordionModule.forRoot()
  ]
})
export class AdminPageModule { }
