System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var Contractor;
    return {
        setters:[],
        execute: function() {
            Contractor = (function () {
                function Contractor(ID, Name, Nip, Street, Number, ApartmentNumber, ZipCode, City, PersonToInvoice) {
                    this.ID = ID;
                    this.Name = Name;
                    this.Nip = Nip;
                    this.Street = Street;
                    this.Number = Number;
                    this.ApartmentNumber = ApartmentNumber;
                    this.ZipCode = ZipCode;
                    this.City = City;
                    this.PersonToInvoice = PersonToInvoice;
                }
                return Contractor;
            }());
            exports_1("Contractor", Contractor);
        }
    }
});
