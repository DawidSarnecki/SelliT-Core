System.register(["@angular/router", "./contractor.component", "./login.component", "./page-not-found.component"], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var router_1, contractor_component_1, login_component_1, page_not_found_component_1;
    var appRoutes, AppRoutingProviders, AppRouting;
    return {
        setters:[
            function (router_1_1) {
                router_1 = router_1_1;
            },
            function (contractor_component_1_1) {
                contractor_component_1 = contractor_component_1_1;
            },
            function (login_component_1_1) {
                login_component_1 = login_component_1_1;
            },
            function (page_not_found_component_1_1) {
                page_not_found_component_1 = page_not_found_component_1_1;
            }],
        execute: function() {
            appRoutes = [
                {
                    path: "",
                    component: contractor_component_1.ContractorComponent
                },
                {
                    path: "home",
                    redirectTo: ""
                },
                {
                    path: "contractor",
                    component: contractor_component_1.ContractorComponent
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
