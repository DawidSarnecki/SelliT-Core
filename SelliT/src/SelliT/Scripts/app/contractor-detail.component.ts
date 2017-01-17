import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {Contractor} from "./contractor";
import {ContractorService} from "./contractor.service";

@Component({
    selector: "contractor-detail",
    template: `
        <div *ngIf="contractor" class="details">
            <h2>{{contractor.Name}} - Edit/Add </h2>
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
                    <input [(ngModel)]="contractor.PersonToInvoice" placeholder="Insert..."/>
                </li>
            </ul>
            <div *ngIf="contractor.ID.indexOf('new') == 0" class="insert">
                <input type="button" value="Save" (click)="onInsert(contractor)" />
                <input type="button" value="Cancel" (click)="onBack()" />
            </div>
            <div *ngIf="contractor.ID.indexOf('new') == -1" class="update">
                <input type="button" value="Update" (click)="onUpdate(contractor)" />
                <input type="button" value="Delete" (click)="onDelete(contractor)" />
                <input type="button" value="Cancel" (click)="onBack()" />
            </div>
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
        if (id == "new") {
            console.log("inserting a new contractor");
            this.contractor = new Contractor(id, "New Contractor", null, null, null, null, null, null, null, null);
        }
        else if (id)
        {
            this.contractorService.get(id)
                .subscribe(contractor => this.contractor = contractor);
        }
        else {
            console.log("Invalid id: " );
                this.router.navigate([""]);
            }
    }

    onInsert(item: Contractor) {
        this.contractorService.add(item).subscribe(
            (data) => {
                this.contractor = data;
                console.log("Item " + this.contractor.ID + " has been added.");
                this.router.navigate(["contractor"]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(item: Contractor) {
        this.contractorService.update(item).subscribe(
            (data) => {
                this.contractor = data;
                console.log("Item " + this.contractor.ID + " has been updated.");
                this.router.navigate([""]);
            },
            (error) => console.log(error)
        );
    }
    onDelete(item: Contractor) {
        var id = item.ID;
        this.contractorService.delete(id).subscribe(
            (data) => {
                console.log("Item " + id + " has been deleted.");
                this.router.navigate(["contractor"]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate(["contractor"]);
    }


}
