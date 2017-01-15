System.register(["@angular/core", "./contractor.service"], function(exports_1, context_1) {
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
    var core_1, contractor_service_1;
    var ContractorListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (contractor_service_1_1) {
                contractor_service_1 = contractor_service_1_1;
            }],
        execute: function() {
            ContractorListComponent = (function () {
                function ContractorListComponent(contractorService) {
                    this.contractorService = contractorService;
                }
                ContractorListComponent.prototype.ngOnInit = function () {
                    this.getLatest();
                };
                ContractorListComponent.prototype.getLatest = function () {
                    var _this = this;
                    this.contractorService.getLatest()
                        .subscribe(function (latestContractors) { return _this.contractors = latestContractors; }, function (error) { return _this.errorMsg = error; });
                };
                ContractorListComponent.prototype.onSelect = function (contractor) {
                    this.selectedContractor = contractor;
                    console.log("Selected contractor with ID: " + this.selectedContractor.ID);
                };
                ContractorListComponent = __decorate([
                    core_1.Component({
                        selector: "contractor-list",
                        template: "\n        <h2>Latest Used Contractors</h2>\n            <ul class=\"contractors\">\n                <li *ngFor=\"let contractor of contractors\"\n                    [class.selected]=\"contractor === selectedContractor\"\n                    (click) =\"onSelect(contractor)\">\n                    <span>{{contractor.Name}}</span>\n                </li>\n            </ul>\n            <contractor-detail *ngIf=\"selectedContractor\" [contractor]=\"selectedContractor\"></contractor-detail>\n            ",
                        styles: ["\n        ul.contractors li { \n            cursor: pointer;}\n        ul.contractors li.selected { \n            background-color: #d1d1e0;}\n    "]
                    }), 
                    __metadata('design:paramtypes', [contractor_service_1.ContractorService])
                ], ContractorListComponent);
                return ContractorListComponent;
            }());
            exports_1("ContractorListComponent", ContractorListComponent);
        }
    }
});
