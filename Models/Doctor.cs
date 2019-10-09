using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMRapp.Models
{
    public class Doctor
    {
        public int DoctorID { get; set; }
	[Required]
	[Display(Name = "Full Name"),StringLength(50, MinimumLength=3),RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
	public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }
	public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}