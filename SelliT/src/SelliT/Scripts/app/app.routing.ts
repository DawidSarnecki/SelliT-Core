import {ModuleWithProviders} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {ContractorComponent} from "./contractor.component";
import {ContractorDetailComponent} from "./contractor-detail.component";
import {LoginComponent} from "./login.component";
import {InvoiceComponent} from "./invoice.component";
import {PageNotFoundComponent} from "./page-not-found.component";
import {ProductComponent} from "./product.component";
import {ProductDetailComponent} from "./product-detail.component";


const appRoutes: Routes = [
    {
        path: "",
        component: InvoiceComponent
    },
    {
        path: "home",
        redirectTo: ""
    },
    {
        path: "contractor",
        component: ContractorComponent
    },
    {
        path: "contractor/:id",
        component: ContractorDetailComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "product",
        component: ProductComponent
    },
    {
        path: "product/:id",
        component: ProductDetailComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);