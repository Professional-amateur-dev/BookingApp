import { RoomType } from '../../shared/models/roomType';

export interface RoomTypeListResponse {
    success: boolean;
    roomType: RoomType[];
    count: number;
    perPage: number;
    page: number;
}