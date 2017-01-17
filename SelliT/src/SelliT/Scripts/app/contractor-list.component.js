System.register(["@angular/core", "@angular/router", "./contractor.service"], function(exports_1, context_1) {
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
    var core_1, router_1, contractor_service_1;
    var ContractorListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (contractor_service_1_1) {
                contractor_service_1 = contractor_service_1_1;
            }],
        execute: function() {
            ContractorListComponent = (function () {
                function ContractorListComponent(contractorService, router) {
                    this.contractorService = contractorService;
                    this.router = router;
                }
                ContractorListComponent.prototype.ngOnInit = function () {
                    this.getLatest();
                };
                ContractorListComponent.prototype.getLatest = function () {
                    var _this = this;
                    this.contractorService.getLatest()
                        .subscribe(function (latestContractors) { return _this.contractors = latestContractors; }, function (error) { return _this.errorInfo = error; });
                };
                ContractorListComponent.prototype.onSelect = function (contractor) {
                    this.selectedContractor = contractor;
                    console.log("Selected contractor with ID: " + this.selectedContractor.ID);
                    this.router.navigate(['contractor', this.selectedContractor.ID]);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], ContractorListComponent.prototype, "class", void 0);
                ContractorListComponent = __decorate([
                    core_1.Component({
                        selector: "contractor-list",
                        template: "\n        <div id=\"list\">\n            <table id=\"items\">\n                <caption>Contractors</caption>\n                <tr>\n                    <th>Name</th>\n                    <th>NIP</th>\n                    <th>Address</th>\n                </tr>\n                <tr *ngFor=\"let contractor of contractors\" (click) =\"onSelect(contractor)\">\n                    <td>{{contractor.Name}}</td>\n                    <td>{{contractor.NIP}}</td>\n                    <td>{{contractor.Address}}</td>\n                </tr>\n            </table>\n        <div>\n            ",
                        styles: ["\n        #list {overflow-x:auto;}\n        #items {\n            border-collapse: collapse;\n            width: 100%;}\n        #items td, #items th, #items caption {\n            border: 1px solid #ddd;\n            padding: 8px;}\n        #items caption {\n            font-size: 1.2em;\n            font-weight: bold;\n            letter-spacing: 2px;}\n        #items tr:nth-child(even){background-color: #f2f2f2;}\n        #items tr:hover {background-color: #4db8ff;}\n        #items th, #items caption {\n            padding-top: 12px;\n            padding-bottom: 12px;\n            text-align: left;\n            background-color: black;\n            color: white;}\n    "]
                    }), 
                    __metadata('design:paramtypes', [contractor_service_1.ContractorService, router_1.Router])
                ], ContractorListComponent);
                return ContractorListComponent;
            }());
            exports_1("ContractorListComponent", ContractorListComponent);
        }
    }
});
