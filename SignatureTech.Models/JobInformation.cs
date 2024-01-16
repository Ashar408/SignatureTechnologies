using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.Models
{
    public class JobInformation
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string  Department { get; set; }
        [Required]
        public DateTime  StartDate { get; set; }
        [Required]
        public string  WorkLocation { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        public int EmployeeDetailId { get; set; }
        [ValidateNever]
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
