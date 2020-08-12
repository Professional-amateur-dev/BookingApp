import { RoomServiceType } from "./roomServiceType";

export interface RoomService {
    id: number;
    name:string;
    price:number;
    roomServiceType: RoomServiceType[];
}