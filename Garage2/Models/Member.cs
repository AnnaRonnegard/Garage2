using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Garage2.Models
{
    public class Member
    {
        public int Id { get; set; } 
        [Display(Name="First Name")]
        [Required]                              //Text box cannot be empty
        [StringLength(20, MinimumLength=2)]               //Maximum Length = 10
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]                              //Text box cannot be empty
        [StringLength(20, MinimumLength = 1)]               //Maximum Length = 10
        public string LastName { get; set; }
         [StringLength(25, MinimumLength = 8)]
       //[RegularExpression("([0-9 + -])$", ErrorMessage = "Invalid Telephone Number")]
        [Required(ErrorMessage="Telephone Number Required")]
     //[RegularExpression("[0-9][2,4]-[0-9]{5,}", ErrorMessage = "Entered phone format is not valid.")]

        [Display(Name = "Telephone Number")]
        public string TelephoneNumber { get; set; }

        public DateTime MemberDate { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
        //ovan skapar abstrakt collection 1:m member/vehicle
    }
}