export class Invoice {
    constructor(
        public ID: string,
        public Number: string,
        public ContractorID: string,
        public UserID: string,
        public PayForm: string,
        public CreateDate: string,
        public SaleDate: string,
        public PaymentDate: string,
        public PaidDate: string
    ) { }
}