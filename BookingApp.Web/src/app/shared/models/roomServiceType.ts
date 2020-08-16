import { RoomService } from "./roomService";
import { RoomType } from './roomType';

export interface RoomServiceType {
    id:number;
    RoomService:RoomService;
    roomServiceId: number;
    RoomType:RoomType;
    roomTypeId: number;

}