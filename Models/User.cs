using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class User
    {
        public int UserID { get; set; }

        [Required]
        [Display(Name = "User Name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
             

        [Display(Name = "Email")]
        [StringLength(70, ErrorMessage = "Email address cannot be longer than 70 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters.")]
        public string Address { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Postal code")]
        [StringLength(15, ErrorMessage = "Postal code cannot be longer than 15 characters.")]
        public string PostalCode { get; set; }

        
        [Required]
        [Display(Name = "Birth date")]
        
        public DateTime BirthDate { get; set; }
    }
}