System.register(["@angular/core"], function(exports_1, context_1) {
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
    var core_1;
    var ContractorComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            }],
        execute: function() {
            ContractorComponent = (function () {
                function ContractorComponent() {
                    this.title = " Contractors";
                }
                ContractorComponent = __decorate([
                    core_1.Component({
                        selector: "contractor",
                        template: "\n        <h1>{{title}}</h1>\n        <h3><a class=\"add\" [routerLink]=\"['new']\"> + New contractor</a></h3>\n        <contractor-list></contractor-list>\n        "
                    }), 
                    __metadata('design:paramtypes', [])
                ], ContractorComponent);
                return ContractorComponent;
            }());
            exports_1("ContractorComponent", ContractorComponent);
        }
    }
});
