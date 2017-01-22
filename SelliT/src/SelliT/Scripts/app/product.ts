export class Product {
    constructor(
        public ID: string,
        public Name: string,
        public Unit: string,
        public Price: string,
        public TaxRate: string,
        public PriceWithTax: string
    ) { }
}