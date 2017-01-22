System.register(["@angular/core", "@angular/router", "./product", "./product.service"], function(exports_1, context_1) {
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
    var core_1, router_1, product_1, product_service_1;
    var ProductDetailComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (product_1_1) {
                product_1 = product_1_1;
            },
            function (product_service_1_1) {
                product_service_1 = product_service_1_1;
            }],
        execute: function() {
            ProductDetailComponent = (function () {
                function ProductDetailComponent(itemService, router, activatedRoute) {
                    this.itemService = itemService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                ProductDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id = this.activatedRoute.snapshot.params['id'];
                    console.log("id: " + id);
                    if (id == "new") {
                        console.log("inserting a new product");
                        this.product = new product_1.Product(id, "New Product", null, null, null, null);
                    }
                    else if (id) {
                        this.itemService.get(id)
                            .subscribe(function (product) { return _this.product = product; });
                    }
                    else {
                        console.log("Invalid id: ");
                        this.router.navigate([""]);
                    }
                };
                ProductDetailComponent.prototype.onInsert = function (item) {
                    var _this = this;
                    this.itemService.add(item).subscribe(function (data) {
                        _this.product = data;
                        console.log("Item " + _this.product.ID + " has been added.");
                        _this.router.navigate(["product"]);
                    }, function (error) { return console.log(error); });
                };
                ProductDetailComponent.prototype.onUpdate = function (item) {
                    var _this = this;
                    this.itemService.update(item).subscribe(function (data) {
                        _this.product = data;
                        console.log("Item " + _this.product.ID + " has been updated.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                ProductDetailComponent.prototype.onDelete = function (item) {
                    var _this = this;
                    var id = item.ID;
                    this.itemService.delete(id).subscribe(function (data) {
                        console.log("Item " + id + " has been deleted.");
                        _this.router.navigate(["product"]);
                    }, function (error) { return console.log(error); });
                };
                ProductDetailComponent.prototype.onBack = function () {
                    this.router.navigate(["product"]);
                };
                ProductDetailComponent = __decorate([
                    core_1.Component({
                        selector: "product-detail",
                        template: "\n        <div *ngIf=\"product\" class=\"edit\">\n            <h2>{{product.Name}} - Edit </h2>\n            <ul>\n                <li>\n                    <label>Name:</label>\n                    <input [(ngModel)]=\"product.Name\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Unit:</label>\n                    <input [(ngModel)]=\"product.Unit\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Price:</label>\n                    <input [(ngModel)]=\"product.Price\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>TaxRate:</label>\n                    <input [(ngModel)]=\"product.TaxRate\" placeholder=\"Insert...\"/>\n                </li>\n            </ul>\n            <div *ngIf=\"product.ID.indexOf('new') == 0\" class=\"insert\">\n                <input type=\"button\" value=\"Save\" (click)=\"onInsert(product)\" />\n                <input type=\"button\" value=\"Cancel\" (click)=\"onBack()\" />\n            </div>\n            <div *ngIf=\"product.ID.indexOf('new') == -1\" class=\"update\">\n                <input type=\"button\" value=\"Update\" (click)=\"onUpdate(product)\" />\n                <input type=\"button\" value=\"Delete\" (click)=\"onDelete(product)\" />\n                <input type=\"button\" value=\"Cancel\" (click)=\"onBack()\" />\n            </div>\n        </div>\n            ",
                        styles: ["\n        .edit {\n            margin: 10px;\n            padding: 10px 10px;\n            border: 1px solid;\n            background-color: #d1d1e0;;\n            width: 400px;\n           }\n       \n    "]
                    }), 
                    __metadata('design:paramtypes', [product_service_1.ProductService, router_1.Router, router_1.ActivatedRoute])
                ], ProductDetailComponent);
                return ProductDetailComponent;
            }());
            exports_1("ProductDetailComponent", ProductDetailComponent);
        }
    }
});
