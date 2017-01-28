System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var User;
    return {
        setters:[],
        execute: function() {
            User = (function () {
                function User(ID, UserName, Email, Name, Nip, Street, Number, ApartmentNumber, ZipCode, City, PersonToInvoice, Address) {
                    this.ID = ID;
                    this.UserName = UserName;
                    this.Email = Email;
                    this.Name = Name;
                    this.Nip = Nip;
                    this.Street = Street;
                    this.Number = Number;
                    this.ApartmentNumber = ApartmentNumber;
                    this.ZipCode = ZipCode;
                    this.City = City;
                    this.PersonToInvoice = PersonToInvoice;
                    this.Address = Address;
                }
                return User;
            }());
            exports_1("User", User);
        }
    }
});
