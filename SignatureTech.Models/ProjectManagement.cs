using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.Models
{
    public class ProjectManagement
    {
        public int Id { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectDescription { get; set; }
        [Required]
        public string ClientName { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompleteDate { get; set; }
        [Required]
        [Display(Name = "Completed By")]
        public int EmployeeDetailId { get; set; }
        [ValidateNever]
        public EmployeeDetail EmployeeDetail { get; set; }
    }
}
