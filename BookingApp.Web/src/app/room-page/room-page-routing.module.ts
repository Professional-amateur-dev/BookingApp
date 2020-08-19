import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RoomListComponent } from './room-list/room-list.component';
import { RoomTypeDetailComponent } from './room-type-detail/room-type-detail.component';

const routes: Routes = [
  { path: '', component: RoomListComponent,  },
    { path: ':id', component: RoomTypeDetailComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RoomPageRoutingModule { }
