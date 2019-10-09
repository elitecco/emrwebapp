using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMRapp.Models
{

    public enum Gender
    {
        Male, Female
    }

    public class Patient
    {
        public int PatientID { get; set; }
	[Required]
	[Display(Name = "Full Name"),StringLength(50, MinimumLength=3),RegularExpression(@"^[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }
        public Gender? Gender { get; set; }
	public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
    }
}