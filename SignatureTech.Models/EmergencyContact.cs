using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SignatureTech.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Relationship { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public int EmployeeDetailId { get; set; }
        [ValidateNever]
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
