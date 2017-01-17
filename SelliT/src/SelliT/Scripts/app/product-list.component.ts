import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Product} from "./product";
import {ProductService} from "./product.service";

@Component({
    selector: "product-list",
    template: `
        <div id="list">
            <table id="items">
                <caption>Products</caption>
                <tr>
                    <th>Name</th>
                    <th>Unit</th>
                    <th>Price [PLN]</th>
                    <th>Tax Rate [%]</th>
                </tr>
                <tr *ngFor="let product of products" (click) ="onSelect(product)">
                    <td>{{product.Name}}</td>
                    <td>{{product.Unit}}</td>
                    <td>{{product.Price}}</td>
                    <td>{{product.TaxRate}}</td>
                </tr>
            </table>
        <div>
            `,
    styles: [`
       #list {overflow-x:auto;}
       #items {
            border-collapse: collapse;
            width: 100%;}
       #items td, #items th, #items caption {
            border: 1px solid #ddd;
            padding: 8px;}
       #items caption {
            font-size: 1.2em;
            font-weight: bold;
            letter-spacing: 2px;}
       #items tr:nth-child(even){background-color: #f2f2f2;}
       #items tr:hover {background-color: #4db8ff;}
       #items th, #items caption {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: black;
            color: white;}
    `]
})

export class ProductListComponent implements OnInit {
    selectedProduct: Product;
    @Input() class: string;
    products: Product[];
    errorInfo: string;

    constructor(private itemService: ProductService, private router: Router) { }

    ngOnInit() {
        this.getLatest();
    }

    getLatest() {
        this.itemService.getLatest()
            .subscribe(items => this.products = items,
            error => this.errorInfo = <any>error
            );
    }

    onSelect(product: Product) {
        this.selectedProduct = product;
        console.log("Selected product with ID: " + this.selectedProduct.ID);
        this.router.navigate(['product', this.selectedProduct.ID]);
    }
}