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
    var ContractorDetailComponent;
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
            ContractorDetailComponent = (function () {
                function ContractorDetailComponent(contractorService, router, activatedRoute) {
                    this.contractorService = contractorService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                ContractorDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id = this.activatedRoute.snapshot.params['id'];
                    console.log("id: " + id);
                    if (id) {
                        this.contractorService.get(id).subscribe(function (contractor) { return _this.contractor = contractor; });
                    }
                    else {
                        console.log("Invalid id: ");
                        this.router.navigate([""]);
                    }
                };
                ContractorDetailComponent = __decorate([
                    core_1.Component({
                        selector: "contractor-detail",
                        template: "\n        <div *ngIf=\"contractor\" class=\"details\">\n            <h2>{{contractor.Name}} - Detail View</h2>\n            <ul>\n                <li>\n                    <label>Name:</label>\n                    <input [(ngModel)]=\"contractor.Name\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>NIP:</label>\n                    <input [(ngModel)]=\"contractor.Nip\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Street:</label>\n                    <input [(ngModel)]=\"contractor.Street\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Number:</label>\n                    <input [(ngModel)]=\"contractor.Number\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ApartmentNumber:</label>\n                    <input [(ngModel)]=\"contractor.ApartmentNumber\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ZipCode:</label>\n                    <input [(ngModel)]=\"contractor.ZipCode\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>City:</label>\n                    <input [(ngModel)]=\"contractor.City\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Authorized Person:</label>\n                    <input [(ngModel)]=\"contractor.PerasonToInvoice\" placeholder=\"Insert...\"/>\n                </li>\n            </ul>\n        </div>\n            ",
                        styles: ["\n        .details {\n            margin: 10px;\n            padding: 10px 10px;\n            border: 1px solid;\n            background-color: #d1d1e0;;\n            width: 400px;\n           }\n       \n    "]
                    }), 
                    __metadata('design:paramtypes', [contractor_service_1.ContractorService, router_1.Router, router_1.ActivatedRoute])
                ], ContractorDetailComponent);
                return ContractorDetailComponent;
            }());
            exports_1("ContractorDetailComponent", ContractorDetailComponent);
        }
    }
});
