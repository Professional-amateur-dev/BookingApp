import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomePageModule } from './home-page/home-page.module';

const routes: Routes = [
  { path: 'home', loadChildren: () => import('./home-page/home-page.module').then(m => m.HomePageModule) },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
