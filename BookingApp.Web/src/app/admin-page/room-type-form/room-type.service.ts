import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { RoomType } from '../../shared/models/roomType';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {

  constructor(
    private http: HttpClient
  ) { }

  getRoomTypes(params = {}) {
    return this.http.get<RoomType[]>(environment.apiUrl + '/roomtypes', { params });
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
