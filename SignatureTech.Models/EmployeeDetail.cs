using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignatureTech.Models
{
    public class EmployeeDetail
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [Display(Name = "ID Card")]
        public string IdCard { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DOBirth { get; set; }
        [Required]
        public string MaritalStatus { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [ValidateNever]
        [Display(Name = "Employee Image")]
        public string ImageUrl { get; set; }
    }
}
