import {Component, OnInit} from "@angular/core";
import {Router, ActivatedRoute} from "@angular/router";
import {User} from "./user";
import {UserService} from "./user.service";

@Component({
    selector: "user-detail",
    template: `
        <div *ngIf="user" class="details">
            <h2>{{user.Name}} - Edit/Add </h2>
            <ul>
                <li>
                    <label>Login:</label>
                    <input [(ngModel)]="user.UserName" placeholder="Insert..."/>
                </li>
                <li>
                    <label>E-mail:</label>
                    <input [(ngModel)]="user.Email" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Name:</label>
                    <input [(ngModel)]="user.Name" placeholder="Insert..."/>
                </li>
                <li>
                    <label>NIP:</label>
                    <input [(ngModel)]="user.Nip" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Street:</label>
                    <input [(ngModel)]="user.Street" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Number:</label>
                    <input [(ngModel)]="user.Number" placeholder="Insert..."/>
                </li>
                <li>
                    <label>ApartmentNumber:</label>
                    <input [(ngModel)]="user.ApartmentNumber" placeholder="Insert..."/>
                </li>
                <li>
                    <label>ZipCode:</label>
                    <input [(ngModel)]="user.ZipCode" placeholder="Insert..."/>
                </li>
                <li>
                    <label>City:</label>
                    <input [(ngModel)]="user.City" placeholder="Insert..."/>
                </li>
                <li>
                    <label>Authorized Person:</label>
                    <input [(ngModel)]="user.PersonToInvoice" placeholder="Insert..."/>
                </li>
            </ul>
            <div *ngIf="user.ID.indexOf('new') == 0" class="insert">
                <input type="button" value="Save" (click)="onInsert(user)" />
                <input type="button" value="Cancel" (click)="onBack()" />
            </div>
            <div *ngIf="user.ID.indexOf('new') == -1" class="update">
                <input type="button" value="Update" (click)="onUpdate(user)" />
                <input type="button" value="Delete" (click)="onDelete(user)" />
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

export class UserDetailComponent {
    user:User ;

    constructor(
        private contractorService: UserService,
        private router: Router,
        private activatedRoute: ActivatedRoute)
    { }

    ngOnInit() {
        var id = this.activatedRoute.snapshot.params['id'];
        console.log("id: " + id);
        if (id == "new") {
            console.log("inserting a new user");
            this.user = new User(id, "New User", null, null, null, null, null, null, null, null,null,null);
        }
        else if (id) {
            this.contractorService.get(id)
                .subscribe(user => this.user = user);
        }
        else {
            console.log("Invalid id: ");
            this.router.navigate(["settings"]);
        }
    }

    onInsert(item: User) {
        this.contractorService.add(item).subscribe(
            (data) => {
                this.user = data;
                console.log("Item " + this.user.ID + " has been added.");
                this.router.navigate(["settings"]);
            },
            (error) => console.log(error)
        );
    }

    onUpdate(item: User) {
        this.contractorService.update(item).subscribe(
            (data) => {
                this.user = data;
                console.log("Item " + this.user.ID + " has been updated.");
                this.router.navigate(["settings"]);
            },
            (error) => console.log(error)
        );
    }
    onDelete(item: User) {
        var id = item.ID;
        this.contractorService.delete(id).subscribe(
            (data) => {
                console.log("Item " + id + " has been deleted.");
                this.router.navigate(["setting"]);
            },
            (error) => console.log(error)
        );
    }

    onBack() {
        this.router.navigate(["settings"]);
    }


}
