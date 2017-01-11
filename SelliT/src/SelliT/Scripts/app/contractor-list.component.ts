import {Component, OnInit} from "@angular/core";
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
                    <span>Name: {{contractor.Name}}</span>
                    <span>; City: {{contractor.City}}</span>
                    <span>; NIp: {{contractor.Nip}}</span>
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
    contractors: Contractor[];
    errorMsg: string;

    constructor(private contractorService: ContractorService) { }

    ngOnInit() {
        this.getLatest();
    }

    getLatest() {
        this.contractorService.getLatest()
            .subscribe(latestContractors => this.contractors = latestContractors,
            error => this.errorMsg = <any>error
            );
    }

    onSelect(contractor: Contractor) {
        this.selectedContractor = contractor;
        console.log("Selected contractor with ID: " + this.selectedContractor.ID);
    }
}

   


    
    
    
  

