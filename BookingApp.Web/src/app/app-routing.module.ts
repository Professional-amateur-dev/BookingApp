import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProtestListComponent } from './protests/protest-list/protest-list.component';
import { ProtestDetailComponent } from './protests/protest-detail/protest-detail.component';
import { CityListComponent } from './cities/city-list/city-list.component';
import { CityDetailComponent } from './cities/city-detail/city-detail.component';


const routes: Routes = [
  { path: '', component: ProtestListComponent },
  { path: 'protests', component: ProtestListComponent },
  { path: 'protests/:id', component: ProtestDetailComponent },
  { path: 'cities', component: CityListComponent },
  { path: 'cities/:id', component: CityDetailComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
