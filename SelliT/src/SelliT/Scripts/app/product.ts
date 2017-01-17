export class Product {
    constructor(
        public ID: string,
        public Name: string,
        public Unit: string,
        public Price: number,
        public TaxRate: number
    ) { }
}