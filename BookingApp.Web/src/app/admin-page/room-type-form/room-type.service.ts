import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { RoomType } from '../../shared/models/roomType';
import { RoomTypeListResponse } from 'src/app/room-page/room-list/room-list.response';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {

  constructor(
    private http: HttpClient
  ) { }

  getRoomTypes(params = {}) {
    // GET req na localhost:5001/api/protests?search=abc
    return this.http.get<RoomTypeListResponse>(environment.apiUrl + '/roomtypes', { params });
  }

  getRoomType(id: number) {
    return this.http.get<RoomType>(environment.apiUrl + '/roomtypes/' + id);
  }

  deleteRoomType(id: number) {
    return this.http.delete(environment.apiUrl + '/roomtypes/' + id);
  }

  postRoomType(roomType: RoomType) {
    return this.http.post<RoomType>(environment.apiUrl + '/roomtypes', roomType);
  }

  updateRoomType(roomType: RoomType, id:number) {
    return this.http.put<RoomType>(environment.apiUrl + '/roomtypes/' + id, roomType);
  }
}
