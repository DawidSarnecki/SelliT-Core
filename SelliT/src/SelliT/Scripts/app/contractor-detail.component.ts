import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {Contractor} from "./contractor";
import {ContractorService} from "./contractor.service";

@Component({
    selector: "contractor-detail",
    template: `
        <div *ngIf="contractor" class="details">
            <h2>{{contractor.Name}} - Detail View</h2>
            <ul>
                <li>
                    <label>Name:</label>
                    <input [(ngModel)]="contractor.Name" placeholder="Insert..."/>
                </li>
                <li>
                    <label>NIP:</label>
                    <input [(ngModel)]="contractor.Nip" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Street:</label>
                    <input [(ngModel)]="contractor.Street" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Number:</label>
                    <input [(ngModel)]="contractor.Number" placeholder="Insert..."/>
                </li>
                <li>
                    <label>ApartmentNumber:</label>
                    <input [(ngModel)]="contractor.ApartmentNumber" placeholder="Insert..."/>
                </li>
                <li>
                    <label>ZipCode:</label>
                    <input [(ngModel)]="contractor.ZipCode" placeholder="Insert..."/>
                </li>
                <li>
                    <label>City:</label>
                    <input [(ngModel)]="contractor.City" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Authorized Person:</label>
                    <input [(ngModel)]="contractor.PerasonToInvoice" placeholder="Insert..."/>
                </li>
            </ul>
        </div>
            `,
    styles: [`
        .details {
            margin: 10px;
            padding: 10px 10px;
            border: 1px solid;
            background-color: #d1d1e0;;
            width: 400px;
           }
       
    `]
})

export class ContractorDetailComponent {
    contractor: Contractor;

    constructor(
        private contractorService: ContractorService,
        private router: Router,
        private activatedRoute: ActivatedRoute)
    { }

    ngOnInit() {
        var id = this.activatedRoute.snapshot.params['id'];
        console.log("id: " + id);
        if (id)
        {
            this.contractorService.get(id)
                .subscribe(contractor => this.contractor = contractor);
        }
        else {
            console.log("Invalid id: " );
                this.router.navigate([""]);
            }

    }
}
