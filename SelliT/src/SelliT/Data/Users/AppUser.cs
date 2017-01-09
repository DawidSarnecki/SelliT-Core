using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SelliT.Data.Users
{
    public class AppUser
    {
        #region Constructor
        public AppUser()
        {
        }
        #endregion Constructor

        #region Properties
        [Key]
        [Required]
        public string ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        [Required]
        public string Nip { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Number { get; set; }
        [DefaultValue("")]
        public string ApartmentNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PersonToInvoice { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool IsSeller { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime ModifyDate { get; set; }
        public DateTime RemoveDate { get; set; }
        #endregion Properties

    }

}
