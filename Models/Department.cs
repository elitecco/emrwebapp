using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMRapp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
	[Required]
	[Display(Name = "Description"),StringLength(50, MinimumLength=3),RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
	public virtual ICollection<Doctor> Doctors { get; set; }
    }
}