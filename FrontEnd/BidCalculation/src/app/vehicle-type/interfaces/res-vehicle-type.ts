export interface IResVehicleType {
    data:    IVehicleType[];
    success: boolean;
    message: string;
}

export interface IVehicleType {
    id:         number;
    name:       string;
    rangeFrom:  number;
    rangeUntil: number;
}