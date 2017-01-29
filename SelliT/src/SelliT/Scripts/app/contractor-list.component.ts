import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Contractor} from "./contractor";
import {ContractorService} from "./contractor.service";

@Component({
    selector: "contractor-list",
    template: `
        <div id="list">
            <table id="items">
                <caption>Contractors</caption>
                <tr>
                    <th>Name</th>
                    <th>NIP</th>
                    <th>Street</th>
                    <th>Number</th>
                    <th>Apt. No.</th>
                    <th>ZIP</th>
                    <th>City</th>
                    <th>Authorized pers.</th>
                </tr>
                <tr *ngFor="let contractor of contractors" (click) ="onSelect(contractor)">
                    <td>{{contractor.Name}}</td>
                    <td>{{contractor.Nip}}</td>
                    <td>{{contractor.Street}}</td>
                    <td>{{contractor.Number}}</td>
                    <td>{{contractor.ApartmentNumber}}</td>
                    <td>{{contractor.ZipCode}}</td>
                    <td>{{contractor.City}}</td>
                    <td>{{contractor.PersonToInvoice}}</td>
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

export class ContractorListComponent implements OnInit {
    selectedContractor: Contractor;
    @Input() class: string;
    contractors: Contractor[];
    errorInfo: string;

    constructor(private contractorService: ContractorService, private router: Router) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.contractorService.get()
            .subscribe(latestContractors => this.contractors = latestContractors,
            error => this.errorInfo = <any>error
            );
    }

    onSelect(contractor: Contractor) {
        this.selectedContractor = contractor;
        console.log("Selected contractor with ID: " + this.selectedContractor.ID);
        this.router.navigate(['contractor', this.selectedContractor.ID]);
    }
}