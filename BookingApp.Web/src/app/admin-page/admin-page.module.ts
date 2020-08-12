import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminPageRoutingModule } from './admin-page-routing.module';
import { ServiceFormComponent } from './service-form/service-form.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [ServiceFormComponent],
  imports: [
    CommonModule,
    AdminPageRoutingModule,
    NgbModule
  ]
})
export class AdminPageModule { }
