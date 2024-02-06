export interface IResAssociationFee {
    data:    IAssociationFee[];
    success: boolean;
    message: string;
}

export interface IAssociationFee {
    id:          number;
    description: string;
    rangeFrom:   number;
    rangeUntil:  number;
    totalAmount: number;
}
