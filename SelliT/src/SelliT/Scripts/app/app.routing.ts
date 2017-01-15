import {ModuleWithProviders} from "@angular/core";
import {Routes, RouterModule} from "@angular/router";
import {ContractorComponent} from "./contractor.component";
import {ContractorDetailComponent} from "./contractor-detail.component";
import {LoginComponent} from "./login.component";
import {PageNotFoundComponent} from "./page-not-found.component";

const appRoutes: Routes = [
    {
        path: "",
        component: ContractorComponent
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
        path: '**',
        component: PageNotFoundComponent
    }
];

export const AppRoutingProviders: any[] = [];
export const AppRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);