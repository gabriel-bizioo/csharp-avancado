import { Product } from './products';
import { Store } from './store';
export interface Purchase
{
    id: number;
    payment: number;
    confirmationNumber: number;
    product: Product;
    store: Store;
    purchaseDate: Date;
    purchaseValue: number;
}

export interface Sale
{
    id: number;
    payment: number;
    confirmationNumber: number;
    product: Product;
    client: string
    purchaseDate: Date;
    purchaseValue: number;
}