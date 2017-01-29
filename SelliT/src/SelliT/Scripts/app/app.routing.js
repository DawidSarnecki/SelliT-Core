System.register(["@angular/router", "./contractor.component", "./contractor-detail.component", "./login.component", "./invoice.component", "./invoice-detail.component", "./page-not-found.component", "./product.component", "./product-detail.component", "./user.component", "./user-detail.component"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, contractor_component_1, contractor_detail_component_1, login_component_1, invoice_component_1, invoice_detail_component_1, page_not_found_component_1, product_component_1, product_detail_component_1, user_component_1, user_detail_component_1;
    var appRoutes, AppRoutingProviders, AppRouting;
    return {
        setters:[
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (contractor_component_1_1) {
                contractor_component_1 = contractor_component_1_1;
            },
            function (contractor_detail_component_1_1) {
                contractor_detail_component_1 = contractor_detail_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (invoice_component_1_1) {
                invoice_component_1 = invoice_component_1_1;
            },
            function (invoice_detail_component_1_1) {
                invoice_detail_component_1 = invoice_detail_component_1_1;
            },
            function (page_not_found_component_1_1) {
                page_not_found_component_1 = page_not_found_component_1_1;
            },
            function (product_component_1_1) {
                product_component_1 = product_component_1_1;
            },
            function (product_detail_component_1_1) {
                product_detail_component_1 = product_detail_component_1_1;
            },
            function (user_component_1_1) {
                user_component_1 = user_component_1_1;
            },
            function (user_detail_component_1_1) {
                user_detail_component_1 = user_detail_component_1_1;
            }],
        execute: function() {
            appRoutes = [
                {
                    path: "",
                    component: invoice_component_1.InvoiceComponent
                },
                {
                    path: "home",
                    redirectTo: ""
                },
                {
                    path: "invoice",
                    component: invoice_component_1.InvoiceComponent
                },
                {
                    path: "invoice/:id",
                    component: invoice_detail_component_1.InvoiceDetailComponent
                },
                {
                    path: "invoice/:new",
                    component: invoice_detail_component_1.InvoiceDetailComponent
                },
                {
                    path: "contractor",
                    component: contractor_component_1.ContractorComponent
                },
                {
                    path: "contractor/:id",
                    component: contractor_detail_component_1.ContractorDetailComponent
                },
                {
                    path: "product",
                    component: product_component_1.ProductComponent
                },
                {
                    path: "product/:id",
                    component: product_detail_component_1.ProductDetailComponent
                },
                {
                    path: "settings",
                    component: user_component_1.UserComponent
                },
                {
                    path: "settings/:id",
                    component: user_detail_component_1.UserDetailComponent
                },
                {
                    path: "login",
                    component: login_component_1.LoginComponent
                },
                {
                    path: '**',
                    component: page_not_found_component_1.PageNotFoundComponent
                }
            ];
            exports_1("AppRoutingProviders", AppRoutingProviders = []);
            exports_1("AppRouting", AppRouting = router_1.RouterModule.forRoot(appRoutes));
        }
    }
});
