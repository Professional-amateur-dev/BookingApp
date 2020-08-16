import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { RoomServiceType } from '../../shared/models/roomServiceType';

@Injectable({
  providedIn: 'root'
})
export class RoomServiceTypeService {

  constructor(
    private http: HttpClient
  ) { }

  getRoomServiceTypes(params = {}) {
    return this.http.get<RoomServiceType[]>(environment.apiUrl + '/roomservicetypes', { params });
  }

  getRoomServiceType(id: number) {
    return this.http.get<RoomServiceType>(environment.apiUrl + '/roomservicetypes/' + id);
  }

  deleteRoomServiceType(id: number) {
    return this.http.delete(environment.apiUrl + '/roomservicetypes/' + id);
  }

  postRoomServiceType(roomServiceType: RoomServiceType) {
    return this.http.post<RoomServiceType>(environment.apiUrl + '/roomservicetypes', roomServiceType);
  }

  updateRoomServiceType(roomServiceType: RoomServiceType, id:number) {
    return this.http.put<RoomServiceType>(environment.apiUrl + '/roomservicetypes/' + id, roomServiceType);
  }
}
