import { Product } from './products';
import { Store } from './store';
export interface Purchase
{
    id: number;
    payment: number;
    confirmation_number: number;
    number_nf: number;
    product: Product;
    store: Store;
    purchase_date: Date;
    purchase_value: number;
}