System.register(["@angular/core", "@angular/platform-browser", "@angular/http", "@angular/forms", "@angular/router", "rxjs/Rx", "./app.routing", "./app.component", "./contractor.component", "./contractor-detail.component", "./contractor-list.component", "./invoice.component", "./contractor.service", "./product.component", "./product-detail.component", "./product-list.component", "./product.service", "./login.component", "./page-not-found.component", "./user.component", "./user-detail.component", "./user-list.component", "./user.service"], function(exports_1, context_1) {
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
    var core_1, platform_browser_1, http_1, forms_1, router_1, app_routing_1, app_component_1, contractor_component_1, contractor_detail_component_1, contractor_list_component_1, invoice_component_1, contractor_service_1, product_component_1, product_detail_component_1, product_list_component_1, product_service_1, login_component_1, page_not_found_component_1, user_component_1, user_detail_component_1, user_list_component_1, user_service_1;
    var AppModule;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (platform_browser_1_1) {
                platform_browser_1 = platform_browser_1_1;
            },
            function (http_1_1) {
                http_1 = http_1_1;
            },
            function (forms_1_1) {
                forms_1 = forms_1_1;
            },
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (_1) {},
            function (app_routing_1_1) {
                app_routing_1 = app_routing_1_1;
            },
            function (app_component_1_1) {
                app_component_1 = app_component_1_1;
            },
            function (contractor_component_1_1) {
                contractor_component_1 = contractor_component_1_1;
            },
            function (contractor_detail_component_1_1) {
                contractor_detail_component_1 = contractor_detail_component_1_1;
            },
            function (contractor_list_component_1_1) {
                contractor_list_component_1 = contractor_list_component_1_1;
            },
            function (invoice_component_1_1) {
                invoice_component_1 = invoice_component_1_1;
            },
            function (contractor_service_1_1) {
                contractor_service_1 = contractor_service_1_1;
            },
            function (product_component_1_1) {
                product_component_1 = product_component_1_1;
            },
            function (product_detail_component_1_1) {
                product_detail_component_1 = product_detail_component_1_1;
            },
            function (product_list_component_1_1) {
                product_list_component_1 = product_list_component_1_1;
            },
            function (product_service_1_1) {
                product_service_1 = product_service_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (page_not_found_component_1_1) {
                page_not_found_component_1 = page_not_found_component_1_1;
            },
            function (user_component_1_1) {
                user_component_1 = user_component_1_1;
            },
            function (user_detail_component_1_1) {
                user_detail_component_1 = user_detail_component_1_1;
            },
            function (user_list_component_1_1) {
                user_list_component_1 = user_list_component_1_1;
            },
            function (user_service_1_1) {
                user_service_1 = user_service_1_1;
            }],
        execute: function() {
            AppModule = (function () {
                function AppModule() {
                }
                AppModule = __decorate([
                    core_1.NgModule({
                        // directives, components, and pipes
                        declarations: [
                            app_component_1.AppComponent,
                            contractor_component_1.ContractorComponent,
                            contractor_list_component_1.ContractorListComponent,
                            contractor_detail_component_1.ContractorDetailComponent,
                            invoice_component_1.InvoiceComponent,
                            product_component_1.ProductComponent,
                            product_list_component_1.ProductListComponent,
                            product_detail_component_1.ProductDetailComponent,
                            login_component_1.LoginComponent,
                            user_component_1.UserComponent,
                            user_list_component_1.UserListComponent,
                            user_detail_component_1.UserDetailComponent,
                            page_not_found_component_1.PageNotFoundComponent
                        ],
                        // modules
                        imports: [
                            platform_browser_1.BrowserModule,
                            http_1.HttpModule,
                            forms_1.FormsModule,
                            router_1.RouterModule,
                            app_routing_1.AppRouting
                        ],
                        // providers
                        providers: [
                            contractor_service_1.ContractorService,
                            product_service_1.ProductService,
                            user_service_1.UserService
                        ],
                        bootstrap: [
                            app_component_1.AppComponent
                        ]
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppModule);
                return AppModule;
            }());
            exports_1("AppModule", AppModule);
        }
    }
});
