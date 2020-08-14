import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { RoomService } from '../shared/models/roomService';

@Injectable({
  providedIn: 'root'
})
export class RoomServiceService {

  constructor(
    private http: HttpClient
  ) { }

  getRoomService(id: number) {
    return this.http.get<RoomService>(environment.apiUrl + '/roomservices/' + id);
  }

  deleteRoomService(id: number) {
    return this.http.delete(environment.apiUrl + '/roomservices/' + id);
  }

  postRoomService(roomService: RoomService) {
    return this.http.post<RoomService>(environment.apiUrl + '/roomservices', roomService);
  }

}
