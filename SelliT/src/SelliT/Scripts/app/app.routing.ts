import {ModuleWithProviders} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {ContractorComponent} from "./contractor.component";
import {ContractorDetailComponent} from "./contractor-detail.component";
import {LoginComponent} from "./login.component";
import {InvoiceComponent} from "./invoice.component";
import {InvoiceDetailComponent} from "./invoice-detail.component";
import {PageNotFoundComponent} from "./page-not-found.component";
import {ProductComponent} from "./product.component";
import {ProductDetailComponent} from "./product-detail.component";
import {UserComponent} from "./user.component";
import {UserDetailComponent} from "./user-detail.component";

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
        path: "invoice",
        component: InvoiceComponent
    },
    {
        path: "invoice/:id",
        component: InvoiceDetailComponent
    },
    {
        path: "invoice/:new",
        component: InvoiceDetailComponent
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
        path: "product",
        component: ProductComponent
    },
    {
        path: "product/:id",
        component: ProductDetailComponent
    },
    {
        path: "settings",
        component: UserComponent
    },
    {
        path: "settings/:id",
        component: UserDetailComponent
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);