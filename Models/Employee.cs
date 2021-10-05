using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShadracPhoneRepairFinial1.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Enter Name of Employee")]
        public string EmpName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Enter Surname")]
        public string EmpSurname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Enter Email of Employee")]
        public string EmpEmail { get; set; }

        [Required]
        [Display(Name = "Enter Default Password ")]
        public string EmpPassword { get; set; }

        [Display(Name = "Enter Work Rate")]
        public double EmpRate { get; set; }

        [Display(Name = "Enter Total work hours per week")]
        public int EmpHours { get; set; }

        public double EmpWage { get; set; }

        [Required]
        [StringLength(25)]
        public string EmployeeRole { get; set; }

        public double GetEmployeeWage()
        {
            return (EmpRate * EmpHours);
        }
    }
}
