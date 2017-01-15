System.register(["@angular/core", "@angular/http", "rxjs/Observable"], function(exports_1, context_1) {
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
    var core_1, http_1, Observable_1;
    var ContractorService;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (Observable_1_1) {
                Observable_1 = Observable_1_1;
            }],
        execute: function() {
            ContractorService = (function () {
                function ContractorService(http) {
                    this.http = http;
                    // base web api URL
                    this.baseUrl = "api/contractors/";
                }
                ContractorService.prototype.handledError = function (error) {
                    // print error in the console
                    console.error(error);
                    return Observable_1.Observable.throw(error.json().error || "A server error occurred");
                };
                // calls the [GET] /api/contractors/GetLatest/{n} Web API method to get the n items.
                ContractorService.prototype.getLatest = function (num) {
                    var url = this.baseUrl + "GetLatest/";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                // calls the [GET] /api/contractors/{ID} Web API method to get the item with the give ID.
                ContractorService.prototype.get = function (id) {
                    if (id == null) {
                        throw new Error("ID is required!");
                    }
                    var url = this.baseUrl + id;
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                ContractorService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], ContractorService);
                return ContractorService;
            }());
            exports_1("ContractorService", ContractorService);
        }
    }
});
