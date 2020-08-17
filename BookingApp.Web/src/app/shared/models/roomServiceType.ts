import { RoomService } from "./roomService";
import { RoomType } from './roomType';

export interface RoomServiceType {
    id:number;
    roomService:RoomService;
    roomServiceId: number;
    roomType:RoomType;
    roomTypeId: number;

}