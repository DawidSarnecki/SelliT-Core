System.register(["@angular/core", "@angular/router", "./product.service"], function(exports_1, context_1) {
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
    var core_1, router_1, product_service_1;
    var ProductListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (product_service_1_1) {
                product_service_1 = product_service_1_1;
            }],
        execute: function() {
            ProductListComponent = (function () {
                function ProductListComponent(itemService, router) {
                    this.itemService = itemService;
                    this.router = router;
                }
                ProductListComponent.prototype.ngOnInit = function () {
                    this.getLatest();
                };
                ProductListComponent.prototype.getLatest = function () {
                    var _this = this;
                    this.itemService.getLatest()
                        .subscribe(function (items) { return _this.products = items; }, function (error) { return _this.errorInfo = error; });
                };
                ProductListComponent.prototype.onSelect = function (product) {
                    this.selectedProduct = product;
                    console.log("Selected product with ID: " + this.selectedProduct.ID);
                    this.router.navigate(['product', this.selectedProduct.ID]);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], ProductListComponent.prototype, "class", void 0);
                ProductListComponent = __decorate([
                    core_1.Component({
                        selector: "product-list",
                        template: "\n        <div id=\"list\">\n            <table id=\"items\">\n                <caption>Products</caption>\n                <tr>\n                    <th>Name</th>\n                    <th>Unit</th>\n                    <th>Price [PLN]</th>\n                    <th>TaxRate [%]</th>\n                </tr>\n                <tr *ngFor=\"let product of products\" (click) =\"onSelect(product)\">\n                    <td>{{product.Name}}</td>\n                    <td>{{product.Unit}}</td>\n                    <td>{{product.Price}}</td>\n                    <td>{{product.TaxRate}}</td>\n                </tr>\n            </table>\n        <div>\n            ",
                        styles: ["\n       #list {overflow-x:auto;}\n       #items {\n            border-collapse: collapse;\n            width: 100%;}\n       #items td, #items th, #items caption {\n            border: 1px solid #ddd;\n            padding: 8px;}\n       #items caption {\n            font-size: 1.2em;\n            font-weight: bold;\n            letter-spacing: 2px;}\n       #items tr:nth-child(even){background-color: #f2f2f2;}\n       #items tr:hover {background-color: #4db8ff;}\n       #items th, #items caption {\n            padding-top: 12px;\n            padding-bottom: 12px;\n            text-align: left;\n            background-color: black;\n            color: white;}\n    "]
                    }), 
                    __metadata('design:paramtypes', [product_service_1.ProductService, router_1.Router])
                ], ProductListComponent);
                return ProductListComponent;
            }());
            exports_1("ProductListComponent", ProductListComponent);
        }
    }
});
