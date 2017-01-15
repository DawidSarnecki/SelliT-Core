import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {Contractor} from "./contractor";
import {ContractorService} from "./contractor.service";

@Component({
    selector: "contractor-list",
    template: `
        <h2>Latest Used Contractors</h2>
            <ul class="contractors">
                <li *ngFor="let contractor of contractors"
                    [class.selected]="contractor === selectedContractor"
                    (click) ="onSelect(contractor)">
                    <span>{{contractor.Name}}</span>
                </li>
            </ul>
            `,
    styles: [`
        ul.contractors li { 
            cursor: pointer;}
        ul.contractors li.selected { 
            background-color: #d1d1e0;}
    `]
})

export class ContractorListComponent implements OnInit {
    selectedContractor: Contractor;
    @Input() class: string;
    contractors: Contractor[];
    errorInfo: string;

    constructor(private contractorService: ContractorService, private router: Router) { }

    ngOnInit() {
        this.getLatest();
    }

    getLatest() {
        this.contractorService.getLatest()
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