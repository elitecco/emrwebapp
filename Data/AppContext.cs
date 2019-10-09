using System;
using Microsoft.EntityFrameworkCore;
using EMRapp.Models;

namespace EMRapp.Data
{
    public class ThisAppContext : DbContext
    {
        public ThisAppContext (DbContextOptions<ThisAppContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
	public DbSet<Doctor> Doctor { get; set; }
	public DbSet<Patient> Patient { get; set; }
	public DbSet<MedicalRecord> MedicalRecord { get; set; }
    }
}