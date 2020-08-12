import { Component, OnInit } from '@angular/core';



@Component({
  selector: 'app-gallery-info',
  templateUrl: './gallery-info.component.html',
  styleUrls: ['./gallery-info.component.scss']
})
export class GalleryInfoComponent implements OnInit {

  slides = [
    {image: 'https://i.pinimg.com/originals/c6/60/24/c66024ea79527d9bbafe79ed171558b9.jpg'},
    {image: 'https://i.pinimg.com/originals/18/40/f4/1840f47447d6727f9591b1127ea0db71.jpg'},
    {image: 'https://i.pinimg.com/originals/80/c8/73/80c873d2bfc5e58d72381d5380b1620a.jpg'}
  ];

  constructor() { }

  ngOnInit(): void {
  }

}

