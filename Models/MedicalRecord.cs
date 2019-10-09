using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMRapp.Models
{
    public class MedicalRecord
    {
        public int MedicalRecordID { get; set; }
	[DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
	[Required,Display(Name = "Doctor")]
	public int DoctorID { get; set; }
        public virtual Doctor Doctor { get; set; }
	[Required,Display(Name = "Patient")]
	public int PatientID { get; set; }
        public virtual Patient Patient { get; set; }
	[Required,MaxLength(5000)]
	[Display(Name = "Patient Condition")]
	public string PatientCondition { get; set; }
	[Required,MaxLength(5000)]
	[Display(Name = "Doctor Indications")]
	public string Indications { get; set; }
    }
}