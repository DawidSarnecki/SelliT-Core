System.register(["@angular/core", "./contractor"], function (exports_1, context_1) {
    "use strict";
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var __moduleName = context_1 && context_1.id;
    var core_1, contractor_1, ContractorDetailComponent;
    return {
        setters: [
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (contractor_1_1) {
                contractor_1 = contractor_1_1;
            }
        ],
        execute: function () {
            ContractorDetailComponent = (function () {
                function ContractorDetailComponent() {
                }
                return ContractorDetailComponent;
            }());
            __decorate([
                core_1.Input("contractor"),
                __metadata("design:type", contractor_1.Contractor)
            ], ContractorDetailComponent.prototype, "contractor", void 0);
            ContractorDetailComponent = __decorate([
                core_1.Component({
                    selector: "contractor-detail",
                    template: "\n        <div *ngIf=\"contractor\" class=\"details\">\n            <h2>{{contractor.Name}} - Detail View</h2>\n            <ul>\n                <li>\n                    <label>Name:</label>\n                    <input [(ngModel)]=\"contractor.Name\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>NIP:</label>\n                    <input [(ngModel)]=\"contractor.Nip\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Street:</label>\n                    <input [(ngModel)]=\"contractor.Street\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Number:</label>\n                    <input [(ngModel)]=\"contractor.Number\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ApartmentNumber:</label>\n                    <input [(ngModel)]=\"contractor.ApartmentNumber\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ZipCode:</label>\n                    <input [(ngModel)]=\"contractor.ZipCode\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>City:</label>\n                    <input [(ngModel)]=\"contractor.City\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Authorized Person:</label>\n                    <input [(ngModel)]=\"contractor.PerasonToInvoice\" placeholder=\"Insert...\"/>\n                </li>\n            </ul>\n        </div>\n            ",
                    styles: ["\n        .details {\n            margin: 10px;\n            padding: 10px 10px;\n            border: 1px solid;\n            background-color: #d1d1e0;;\n            width: 400px;\n           }\n       \n    "]
                }),
                __metadata("design:paramtypes", [])
            ], ContractorDetailComponent);
            exports_1("ContractorDetailComponent", ContractorDetailComponent);
        }
    };
});
