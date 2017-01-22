System.register(["@angular/core", "@angular/router", "./user.service"], function(exports_1, context_1) {
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
    var core_1, router_1, user_service_1;
    var UserListComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }],
        execute: function() {
            UserListComponent = (function () {
                function UserListComponent(contractorService, router) {
                    this.contractorService = contractorService;
                    this.router = router;
                }
                UserListComponent.prototype.ngOnInit = function () {
                    this.get();
                };
                UserListComponent.prototype.get = function () {
                    var _this = this;
                    this.contractorService.getLatest()
                        .subscribe(function (selectedUsers) { return _this.users = selectedUsers; }, function (error) { return _this.errorInfo = error; });
                };
                UserListComponent.prototype.onSelect = function (user) {
                    this.selectedUser = user;
                    console.log("Selected user with ID: " + this.selectedUser.ID);
                    this.router.navigate(['settings', this.selectedUser.ID]);
                };
                __decorate([
                    core_1.Input(), 
                    __metadata('design:type', String)
                ], UserListComponent.prototype, "class", void 0);
                UserListComponent = __decorate([
                    core_1.Component({
                        selector: "user-list",
                        template: "\n        <div id=\"list\">\n            <table id=\"items\">\n                <caption>User</caption>\n                <tr>\n                    <th>Login</th>\n                    <th>Email</th>\n                    <th>Name</th>\n                    <th>NIP</th>\n                    <th>Street</th>\n                    <th>Number</th>\n                    <th>Apt. No.</th>\n                    <th>ZIP</th>\n                    <th>City</th>\n                    <th>Authorized pers.</th>\n                </tr>\n                <tr *ngFor=\"let user of users\" (click) =\"onSelect(user)\">\n                    <td>{{user.Name}}</td>\n                    <td>{{user.Nip}}</td>\n                    <td>{{user.Street}}</td>\n                    <td>{{user.Number}}</td>\n                    <td>{{user.ApartmentNumber}}</td>\n                    <td>{{user.ZipCode}}</td>\n                    <td>{{user.City}}</td>\n                    <td>{{user.PersonToInvoice}}</td>\n                </tr>\n            </table>\n        <div>\n            ",
                        styles: ["\n        #list {overflow-x:auto;}\n        #items {\n            border-collapse: collapse;\n            width: 100%;}\n        #items td, #items th, #items caption {\n            border: 1px solid #ddd;\n            padding: 8px;}\n        #items caption {\n            font-size: 1.2em;\n            font-weight: bold;\n            letter-spacing: 2px;}\n        #items tr:nth-child(even){background-color: #f2f2f2;}\n        #items tr:hover {background-color: #4db8ff;}\n        #items th, #items caption {\n            padding-top: 12px;\n            padding-bottom: 12px;\n            text-align: left;\n            background-color: black;\n            color: white;}\n    "]
                    }), 
                    __metadata('design:paramtypes', [user_service_1.UserService, router_1.Router])
                ], UserListComponent);
                return UserListComponent;
            }());
            exports_1("UserListComponent", UserListComponent);
        }
    }
});
