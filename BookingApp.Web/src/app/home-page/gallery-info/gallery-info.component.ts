import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-gallery-info',
  templateUrl: './gallery-info.component.html',
  styleUrls: ['./gallery-info.component.scss']
})
export class GalleryInfoComponent implements OnInit {

  images = [944, 1011, 984].map((n) => `https://picsum.photos/id/${n}/900/500`);

  constructor() { }

  ngOnInit(): void {
  }

}

