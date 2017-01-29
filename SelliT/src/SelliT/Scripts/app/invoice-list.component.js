System.register(["@angular/core", "@angular/router", "./invoice.service"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, router_1, invoice_service_1;
    var InvoiceListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (invoice_service_1_1) {
                invoice_service_1 = invoice_service_1_1;
            }],
        execute: function() {
            InvoiceListComponent = (function () {
                function InvoiceListComponent(itemService, router) {
                    this.itemService = itemService;
                    this.router = router;
                }
                InvoiceListComponent.prototype.ngOnInit = function () {
                    this.get();
                };
                InvoiceListComponent.prototype.get = function () {
                    var _this = this;
                    this.itemService.get()
                        .subscribe(function (items) { return _this.invoices = items; }, function (error) { return _this.errorInfo = error; });
                };
                InvoiceListComponent.prototype.onSelect = function (item) {
                    this.selectedInvoice = item;
                    console.log("Selected invoice with ID: " + this.selectedInvoice.ID);
                    this.router.navigate(['invoice', this.selectedInvoice.ID]);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], InvoiceListComponent.prototype, "class", void 0);
                InvoiceListComponent = __decorate([
                    core_1.Component({
                        selector: "invoice-list",
                        template: "\n        <div id=\"list\">\n            <table id=\"items\">\n                <caption>Invoices</caption>\n                <tr>\n                    <th>Number</th>\n                    <th>Contractor Name</th>\n                    <th>Create Date</th>\n                    <th>Sale Date</th>\n                    <th>Pay Form</th>\n                    <th>Payment Date</th>\n                    <th>Paid Date</th>\n                </tr>\n                <tr *ngFor=\"let i of invoices\" (click) =\"onSelect(i)\">\n                    <td>{{i.Number}}</td>\n                    <td>{{i.Contractor.Name}}</td>\n                    <td>{{i.CreateDate}}</td>\n                    <td>{{i.SaleDate}}</td>\n                    <td>{{i.PayForm}}</td>\n                    <td>{{i.PaymentDate}}</td>\n                    <td>{{i.PaidDate}}</td>\n                </tr>\n            </table>\n        <div>\n            ",
                        styles: ["\n       #list {overflow-x:auto;}\n       #items {\n            border-collapse: collapse;\n            width: 100%;}\n       #items td, #items th, #items caption {\n            border: 1px solid #ddd;\n            padding: 8px;}\n       #items caption {\n            font-size: 1.2em;\n            font-weight: bold;\n            letter-spacing: 2px;}\n       #items tr:nth-child(even){background-color: #f2f2f2;}\n       #items tr:hover {background-color: #4db8ff;}\n       #items th, #items caption {\n            padding-top: 12px;\n            padding-bottom: 12px;\n            text-align: left;\n            background-color: black;\n            color: white;}\n    "]
                    }), 
                    __metadata('design:paramtypes', [invoice_service_1.InvoiceService, router_1.Router])
                ], InvoiceListComponent);
                return InvoiceListComponent;
            }());
            exports_1("InvoiceListComponent", InvoiceListComponent);
        }
    }
});
