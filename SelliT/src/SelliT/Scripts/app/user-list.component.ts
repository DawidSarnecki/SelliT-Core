import {Component, Input, OnInit} from "@angular/core";
import {Router} from "@angular/router";
import {User} from "./user";
import {UserService} from "./user.service";

@Component({
    selector: "user-list",
    template: `
        <div id="list">
            <table id="items">
                <caption>User</caption>
                <tr>
                    <th>Login</th>
                    <th>Email</th>
                    <th>Name</th>
                    <th>NIP</th>
                    <th>Street</th>
                    <th>Number</th>
                    <th>Apt. No.</th>
                    <th>ZIP</th>
                    <th>City</th>
                    <th>Authorized pers.</th>
                </tr>
                <tr *ngFor="let user of users" (click) ="onSelect(user)">
                    <td>{{user.UserName}}</td>
                    <td>{{user.Email}}</td>
                    <td>{{user.Name}}</td>
                    <td>{{user.Nip}}</td>
                    <td>{{user.Street}}</td>
                    <td>{{user.Number}}</td>
                    <td>{{user.ApartmentNumber}}</td>
                    <td>{{user.ZipCode}}</td>
                    <td>{{user.City}}</td>
                    <td>{{user.PersonToInvoice}}</td>
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

export class UserListComponent implements OnInit {
    selectedUser: User;
    @Input() class: string;
    users: User[];
    errorInfo: string;

    constructor(private contractorService: UserService, private router: Router) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.contractorService.get()
            .subscribe(selectedUsers => this.users = selectedUsers,
            error => this.errorInfo = <any>error
            );
    }

    onSelect(user: User) {
        this.selectedUser = user;
        console.log("Selected user with ID: " + this.selectedUser.ID);
        this.router.navigate(['settings', this.selectedUser.ID]);
    }
}