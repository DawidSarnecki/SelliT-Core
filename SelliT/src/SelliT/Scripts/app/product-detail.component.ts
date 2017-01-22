import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {Product} from "./product";
import {ProductService} from "./product.service";

@Component({
    selector: "product-detail",
    template: `
        <div *ngIf="product" class="edit">
            <h2>{{product.Name}} - Edit </h2>
            <ul>
                <li>
                    <label>Name:</label>
                    <input [(ngModel)]="product.Name" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Unit:</label>
                    <input [(ngModel)]="product.Unit" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Price:</label>
                    <input [(ngModel)]="product.Price" placeholder="Insert..."/>
                </li>
                <li>
                    <label>TaxRate:</label>
                    <input [(ngModel)]="product.TaxRate" placeholder="Insert..."/>
                </li>
            </ul>
            <div *ngIf="product.ID.indexOf('new') == 0" class="insert">
                <input type="button" value="Save" (click)="onInsert(product)" />
                <input type="button" value="Cancel" (click)="onBack()" />
            </div>
            <div *ngIf="product.ID.indexOf('new') == -1" class="update">
                <input type="button" value="Update" (click)="onUpdate(product)" />
                <input type="button" value="Delete" (click)="onDelete(product)" />
                <input type="button" value="Cancel" (click)="onBack()" />
            </div>
        </div>
            `,
    styles: [`
        .edit {
            margin: 10px;
            padding: 10px 10px;
            border: 1px solid;
            background-color: #d1d1e0;;
            width: 400px;
           }
       
    `]
})

export class ProductDetailComponent {
    product: Product;

    constructor(
        private itemService: ProductService,
        private router: Router,
        private activatedRoute: ActivatedRoute)
    { }

    ngOnInit() {
        var id = this.activatedRoute.snapshot.params['id'];
        console.log("id: " + id);
        if (id == "new") {
            console.log("inserting a new product");
            this.product = new Product(id, "New Product", null, null, null,null);
        }
        else if (id) {
            this.itemService.get(id)
                .subscribe(product => this.product = product);
        }
        else {
            console.log("Invalid id: ");
            this.router.navigate([""]);
        }
    }

    onInsert(item: Product) {
        this.itemService.add(item).subscribe(
            (data) => {
                this.product = data;
                console.log("Item " + this.product.ID + " has been added.");
                this.router.navigate(["product"]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(item: Product) {
        this.itemService.update(item).subscribe(
            (data) => {
                this.product = data;
                console.log("Item " + this.product.ID + " has been updated.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }
    onDelete(item: Product) {
        var id = item.ID;
        this.itemService.delete(id).subscribe(
            (data) => {
                console.log("Item " + id + " has been deleted.");
                this.router.navigate(["product"]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate(["product"]);
    }


}
