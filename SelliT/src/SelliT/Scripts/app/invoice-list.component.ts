import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Invoice} from "./invoice";
import {InvoiceService} from "./invoice.service";

@Component({
    selector: "invoice-list",
    template: `
        <div id="list">
            <table id="items">
                <caption>Invoices</caption>
                <tr>
                    <th>Number</th>
                    <th>Contractor Name</th>
                    <th>Create Date</th>
                    <th>Sale Date</th>
                    <th>Pay Form</th>
                    <th>Payment Date</th>
                    <th>Paid Date</th>
                </tr>
                <tr *ngFor="let i of invoices" (click) ="onSelect(i)">
                    <td>{{i.Number}}</td>
                    <td>{{i.Contractor.Name}}</td>
                    <td>{{i.CreateDate}}</td>
                    <td>{{i.SaleDate}}</td>
                    <td>{{i.PayForm}}</td>
                    <td>{{i.PaymentDate}}</td>
                    <td>{{i.PaidDate}}</td>
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

export class InvoiceListComponent implements OnInit {
    selectedInvoice: Invoice;
    @Input() class: string;
    invoices: Invoice[];
    errorInfo: string;

    constructor(private itemService: InvoiceService, private router: Router) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.itemService.get()
            .subscribe(items => this.invoices = items,
            error => this.errorInfo = <any>error
            );
    }

    onSelect(item: Invoice) {
        this.selectedInvoice = item;
        console.log("Selected invoice with ID: " + this.selectedInvoice.ID);
        this.router.navigate(['invoice', this.selectedInvoice.ID]);
    }
}