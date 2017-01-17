System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Product;
    return {
        setters:[],
        execute: function() {
            Product = (function () {
                function Product(ID, Name, Unit, Price, TaxRate) {
                    this.ID = ID;
                    this.Name = Name;
                    this.Unit = Unit;
                    this.Price = Price;
                    this.TaxRate = TaxRate;
                }
                return Product;
            }());
            exports_1("Product", Product);
        }
    }
});
