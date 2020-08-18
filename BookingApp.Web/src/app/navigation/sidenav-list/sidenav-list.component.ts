import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sidenav-list',
  templateUrl: './sidenav-list.component.html',
  styleUrls: ['./sidenav-list.component.scss']
})
export class SidenavListComponent implements OnInit {
  @Output() sidenavClose = new EventEmitter();
  
 
  constructor(
    private router: Router,
    private toastr: ToastrService
  ) { }
 
  ngOnInit() {
  }
 
  public onSidenavClose = () => {
    this.sidenavClose.emit();
  }

  onLogout() {
    localStorage.clear();
    this.router.navigate(['login']);
    //setTimeout(() => { window.location.reload(); }, 100);
    this.toastr.success('You Have been logged out');
  }
 
}