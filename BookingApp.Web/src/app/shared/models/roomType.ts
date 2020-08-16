import { RoomServiceType } from "./roomServiceType";

export interface RoomType {
    id: number;
    type:string;
    description:string;
    bedCount:number;
    personCount:number;
    surface:number;
    //rooms:Room[];
    roomServiceType: RoomServiceType[];
}