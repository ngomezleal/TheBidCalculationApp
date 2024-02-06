export interface IResBidCalculation {
    data:    IBidCalculation;
    success: boolean;
    message: string;
}

export interface IBidCalculation {
    vehicleBasePrice: number;
    basicUserFee:      number;
    specialFee:        number;
    specialFeeId:      number;
    associationFee:    number;
    associationFeeId:  number;
    fixedAmount:       number;
    totalFee:          number;
}
