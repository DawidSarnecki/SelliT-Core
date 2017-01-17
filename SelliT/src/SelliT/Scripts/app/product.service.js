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
    var ProductService;
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
            ProductService = (function () {
                function ProductService(http) {
                    this.http = http;
                    // base web api URL
                    this.baseUrl = "api/products/";
                }
                ProductService.prototype.handledError = function (error) {
                    // print error in the console
                    console.error(error);
                    return Observable_1.Observable.throw(error.json().error || "A server error occurred");
                };
                // calls the [GET] /api/contractors/GetLatest/{n} Web API method to get the n items.
                ProductService.prototype.getLatest = function (num) {
                    var url = this.baseUrl + "GetLatest/";
                    if (num != null) {
                        url += num;
                    }
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                // calls the [GET] /api/contractors/{ID} Web API method to get the item with the giveN ID.
                ProductService.prototype.get = function (id) {
                    if (id == null) {
                        throw new Error("ID is required!");
                    }
                    var url = this.baseUrl + id;
                    return this.http.get(url)
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                // calls the [POST] api/contractors/ Web API method to ADD a new item.
                ProductService.prototype.add = function (item) {
                    var url = this.baseUrl;
                    return this.http.post(url, JSON.stringify(item), this.getRequestOptions())
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                // calls the [PUT] api/contractors/ Web API method to UPDATE an existing item.
                ProductService.prototype.update = function (item) {
                    var url = this.baseUrl + item.ID;
                    return this.http.put(url, JSON.stringify(item), this.getRequestOptions())
                        .map(function (response) { return response.json(); })
                        .catch(this.handledError);
                };
                // calls the [DELETE] api/contractors/ Web API method to DELETE an item with given ID.
                ProductService.prototype.delete = function (id) {
                    var url = this.baseUrl + id;
                    return this.http.delete(url)
                        .catch(this.handledError);
                };
                // return RequestOptions object to handle Json requests
                ProductService.prototype.getRequestOptions = function () {
                    return new http_1.RequestOptions({
                        headers: new http_1.Headers({ "Content-Type": "application/json" })
                    });
                };
                ProductService = __decorate([
                    core_1.Injectable(), 
                    __metadata('design:paramtypes', [http_1.Http])
                ], ProductService);
                return ProductService;
            }());
            exports_1("ProductService", ProductService);
        }
    }
});
