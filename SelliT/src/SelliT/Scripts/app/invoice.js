System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Invoice;
    return {
        setters:[],
        execute: function() {
            Invoice = (function () {
                function Invoice(ID, Number, ContractorID, UserID, PayForm, CreateDate, SaleDate, PaymentDate, PaidDate) {
                    this.ID = ID;
                    this.Number = Number;
                    this.ContractorID = ContractorID;
                    this.UserID = UserID;
                    this.PayForm = PayForm;
                    this.CreateDate = CreateDate;
                    this.SaleDate = SaleDate;
                    this.PaymentDate = PaymentDate;
                    this.PaidDate = PaidDate;
                }
                return Invoice;
            }());
            exports_1("Invoice", Invoice);
        }
    }
});
