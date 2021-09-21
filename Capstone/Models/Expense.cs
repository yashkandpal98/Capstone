using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name ="Expense Amount")]
        public int ExpenseAmount { get; set; }

        [Required]
        [Display(Name ="Expense Type")]
        public byte ExpenseTypeId { get; set; }
        public ExpenseType ExpenseType { get; set; }

        [Required]
        [Display(Name ="Date Incurred")]
        public DateTime? DateIncurred { get; set; }

        [Required]
        [Display(Name ="Date Submitted")]
        public DateTime? DateSubmitted { get; set; }

        [Required]
        [Display(Name ="Status")]
        public byte StatusId { get; set; }
        public Status Status { get; set; }
    }
}