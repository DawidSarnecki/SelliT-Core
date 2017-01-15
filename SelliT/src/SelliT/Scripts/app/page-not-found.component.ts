import {Component} from "@angular/core";
@Component({
    selector: "page-not-found",
    template: `
        <h1>{{title}}</h1>
            <div>
                I'm so sorry, but this page does not exist.
            </div>
`
})
export class PageNotFoundComponent {
    title = "Page not Found";
}