export interface IResSellerSpecialFee {
    data:    ISellerSpecialFee[];
    success: boolean;
    message: string;
}

export interface ISellerSpecialFee {
    id:                   number;
    description:          string;
    specialFeePercentage: number;
    vehicleTypeId:        number;
}
