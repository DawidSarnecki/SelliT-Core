System.register(["@angular/core", "@angular/router", "./user", "./user.service"], function(exports_1, context_1) {
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
    var core_1, router_1, user_1, user_service_1;
    var UserDetailComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (user_1_1) {
                user_1 = user_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }],
        execute: function() {
            UserDetailComponent = (function () {
                function UserDetailComponent(contractorService, router, activatedRoute) {
                    this.contractorService = contractorService;
                    this.router = router;
                    this.activatedRoute = activatedRoute;
                }
                UserDetailComponent.prototype.ngOnInit = function () {
                    var _this = this;
                    var id = this.activatedRoute.snapshot.params['id'];
                    console.log("id: " + id);
                    if (id == "new") {
                        console.log("inserting a new user");
                        this.user = new user_1.User(id, "New User", null, null, null, null, null, null, null, null, null, null);
                    }
                    else if (id) {
                        this.contractorService.get(id)
                            .subscribe(function (user) { return _this.user = user; });
                    }
                    else {
                        console.log("Invalid id: ");
                        this.router.navigate([""]);
                    }
                };
                UserDetailComponent.prototype.onInsert = function (item) {
                    var _this = this;
                    this.contractorService.add(item).subscribe(function (data) {
                        _this.user = data;
                        console.log("Item " + _this.user.ID + " has been added.");
                        _this.router.navigate(["user"]);
                    }, function (error) { return console.log(error); });
                };
                UserDetailComponent.prototype.onUpdate = function (item) {
                    var _this = this;
                    this.contractorService.update(item).subscribe(function (data) {
                        _this.user = data;
                        console.log("Item " + _this.user.ID + " has been updated.");
                        _this.router.navigate([""]);
                    }, function (error) { return console.log(error); });
                };
                UserDetailComponent.prototype.onDelete = function (item) {
                    var _this = this;
                    var id = item.ID;
                    this.contractorService.delete(id).subscribe(function (data) {
                        console.log("Item " + id + " has been deleted.");
                        _this.router.navigate(["setting"]);
                    }, function (error) { return console.log(error); });
                };
                UserDetailComponent.prototype.onBack = function () {
                    this.router.navigate(["settings"]);
                };
                UserDetailComponent = __decorate([
                    core_1.Component({
                        selector: "user-detail",
                        template: "\n        <div *ngIf=\"user\" class=\"details\">\n            <h2>{{contractor.Name}} - Edit/Add </h2>\n            <ul>\n                <li>\n                    <label>Login:</label>\n                    <input [(ngModel)]=\"contractor.UserName\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>E-mail:</label>\n                    <input [(ngModel)]=\"user.Email\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Name:</label>\n                    <input [(ngModel)]=\"user.Name\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>NIP:</label>\n                    <input [(ngModel)]=\"user.Nip\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Street:</label>\n                    <input [(ngModel)]=\"user.Street\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Number:</label>\n                    <input [(ngModel)]=\"user.Number\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ApartmentNumber:</label>\n                    <input [(ngModel)]=\"user.ApartmentNumber\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>ZipCode:</label>\n                    <input [(ngModel)]=\"user.ZipCode\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>City:</label>\n                    <input [(ngModel)]=\"user.City\" placeholder=\"Insert...\"/>\n                </li>\n                <li>\n                    <label>Authorized Person:</label>\n                    <input [(ngModel)]=\"user.PersonToInvoice\" placeholder=\"Insert...\"/>\n                </li>\n            </ul>\n            <div *ngIf=\"user.ID.indexOf('new') == 0\" class=\"insert\">\n                <input type=\"button\" value=\"Save\" (click)=\"onInsert(user)\" />\n                <input type=\"button\" value=\"Cancel\" (click)=\"onBack()\" />\n            </div>\n            <div *ngIf=\"user.ID.indexOf('new') == -1\" class=\"update\">\n                <input type=\"button\" value=\"Update\" (click)=\"onUpdate(user)\" />\n                <input type=\"button\" value=\"Delete\" (click)=\"onDelete(user)\" />\n                <input type=\"button\" value=\"Cancel\" (click)=\"onBack()\" />\n            </div>\n        </div>\n            ",
                        styles: ["\n        .details {\n            margin: 10px;\n            padding: 10px 10px;\n            border: 1px solid;\n            background-color: #d1d1e0;;\n            width: 400px;\n           }\n       \n    "]
                    }), 
                    __metadata('design:paramtypes', [user_service_1.UserService, router_1.Router, router_1.ActivatedRoute])
                ], UserDetailComponent);
                return UserDetailComponent;
            }());
            exports_1("UserDetailComponent", UserDetailComponent);
        }
    }
});
