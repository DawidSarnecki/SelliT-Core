System.register(["@angular/core", "@angular/router", "./invoice", "./invoice.service"], function(exports_1, context_1) {
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
    var core_1, router_1, invoice_1, invoice_service_1;
    var InvoiceDetailComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (invoice_1_1) {
                invoice_1 = invoice_1_1;
            },
            function (invoice_service_1_1) {
                invoice_service_1 = invoice_service_1_1;
            }],
        execute: function() {
            InvoiceDetailComponent = (function () {
                function InvoiceDetailComponent(itemService, router, activatedRoute) {
                    this.itemService = itemService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                InvoiceDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id = this.activatedRoute.snapshot.params['id'];
                    console.log("id: " + id);
                    if (id == "new") {
                        console.log("inserting a new Invoice");
                        this.invoice = new invoice_1.Invoice(id, "New Number", null, null, null, null, null, null, null, null);
                    }
                    else if (id) {
                        this.itemService.get(id)
                            .subscribe(function (item) { return _this.invoice = item; });
                    }
                    else {
                        console.log("Invalid id: ");
                        this.router.navigate(["invoices"]);
                    }
                };
                InvoiceDetailComponent.prototype.onBack = function () {
                    this.router.navigate(["invoice"]);
                };
                InvoiceDetailComponent = __decorate([
                    core_1.Component({
                        selector: "invoice-detail",
                        template: "\n        <h1>{{title}} DETAILS </h1>\n        <div>\n            TODO.\n        </div>\n        <div class=\"container\" width=\"800px\" id=\"invoice\" >\n            <div class=\"row\">\n              <div class=\"col-xs-12 heading\">\n                INVOICE\n              </div>\n            </div>\n            <div class=\"row branding\">\n              <div class=\"col-xs-6\">\n                <div class=\"invoice-number-container\">\n                  <label for=\"invoice-number\">Invoice #</label><input type=\"text\" id=\"invoice-number\" ng-model=\"invoice.invoice_number\" />\n                </div>\n              </div>\n            </div>\n            <div class=\"row infos\">\n              <div class=\"col-xs-6\">\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.customer_info.name\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.customer_info.web_link\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.customer_info.address1\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.customer_info.address2\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.customer_info.postal\"/></div>\n                <div class=\"input-container\" data-ng-hide='printMode'>\n                  <select ng-model='currencySymbol' ng-options='currency.symbol as currency.name for currency in availableCurrencies'></select>\n                </div>\n              </div>\n              <div class=\"col-xs-6 right\">\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.company_info.name\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.company_info.web_link\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.company_info.address1\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.company_info.address2\"/></div>\n                <div class=\"input-container\"><input type=\"text\" ng-model=\"invoice.company_info.postal\"/></div>\n              </div>\n            </div>\n            <div class=\"items-table\">\n              <div class=\"row header\">\n                <div class=\"col-xs-1\">&nbsp;</div>\n                <div class=\"col-xs-5\">Description</div>\n                <div class=\"col-xs-2\">Quantity</div>\n                <div class=\"col-xs-2\">Cost {{currencySymbol}}</div>\n                <div class=\"col-xs-2 text-right\">Total</div>\n              </div>\n              <div class=\"row invoice-item\" ng-repeat=\"item in invoice.items\" ng-animate=\"'slide-down'\">\n                <div class=\"col-xs-1 remove-item-container\">\n                  <a href ng-hide=\"printMode\" ng-click=\"removeItem(item)\" class=\"btn btn-danger\">[X]</a>\n                </div>\n                <div class=\"col-xs-5 input-container\">\n                  <input ng-model=\"item.description\" placeholder=\"Description\" />\n                </div>\n                <div class=\"col-xs-2 input-container\">\n                  <input ng-model=\"item.qty\" value=\"1\" size=\"4\" ng-required ng-validate=\"integer\" placeholder=\"Quantity\" />\n                </div>\n                <div class=\"col-xs-2 input-container\">\n                  <input ng-model=\"item.cost\" value=\"0.00\" ng-required ng-validate=\"number\" size=\"6\" placeholder=\"Cost\" />\n                </div>\n                <div class=\"col-xs-2 text-right input-container\">\n                  {{item.cost * item.qty | currency: currencySymbol}}\n                </div>\n              </div>\n              <div class=\"row invoice-item\">\n                <div class=\"col-xs-12 add-item-container\" ng-hide=\"printMode\">\n                  <a class=\"btn btn-primary\" href ng-click=\"addItem()\" >[+]</a>\n                </div>\n              </div>\n              <div class=\"row\">\n                <div class=\"col-xs-10 text-right\">Sub Total</div>\n                <div class=\"col-xs-2 text-right\">{{invoiceSubTotal() | currency: currencySymbol}}</div>\n              </div>\n              <div class=\"row\">\n                <div class=\"col-xs-10 text-right\">Tax(%): <input ng-model=\"invoice.tax\" ng-validate=\"number\" style=\"width:43px\"></div>\n                <div class=\"col-xs-2 text-right\">{{calculateTax() | currency: currencySymbol}}</div>\n              </div>\n              <div class=\"row\">\n                <div class=\"col-xs-10 text-right\">Grand Total:</div>\n                <div class=\"col-xs-2 text-right\">{{calculateGrandTotal() | currency: currencySymbol}}</div>\n              </div>\n            </div>\n            <div class=\"row noPrint actions\">\n              <a href=\"#\" class=\"btn btn-primary\" ng-show=\"printMode\" ng-click=\"printInfo()\">Print</a>\n              <a href=\"#\" class=\"btn btn-primary\" ng-click=\"clearLocalStorage()\">Reset</a>\n              <a href=\"#\" class=\"btn btn-primary\" ng-hide=\"printMode\" ng-click=\"printMode = true;\">Turn On Print Mode</a>\n              <a href=\"#\" class=\"btn btn-primary\" ng-show=\"printMode\" ng-click=\"printMode = false;\">Turn Off Print Mode</a>\n            </div>\n          </div>\n"
                    }), 
                    __metadata('design:paramtypes', [invoice_service_1.InvoiceService, router_1.Router, router_1.ActivatedRoute])
                ], InvoiceDetailComponent);
                return InvoiceDetailComponent;
            }());
            exports_1("InvoiceDetailComponent", InvoiceDetailComponent);
        }
    }
});
