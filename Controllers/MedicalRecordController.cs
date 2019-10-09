using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMRapp.Data;
using EMRapp.Models;

namespace EMRapp.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly ThisAppContext _context;

        public MedicalRecordController(ThisAppContext context)
        {
            _context = context;
        }

        // GET: MedicalRecord
        public async Task<IActionResult> Index()
        {
            var thisAppContext = _context.MedicalRecord.Include(m => m.Doctor).Include(m => m.Patient);
            return View(await thisAppContext.ToListAsync());
        }

        // GET: MedicalRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Doctor)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.MedicalRecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // GET: MedicalRecord/Create
        public IActionResult Create()
        {
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Name");
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "Name");
            return View();
        }

        // POST: MedicalRecord/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedicalRecordID,Date,DoctorID,PatientID,PatientCondition,Indications")] MedicalRecord medicalRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicalRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Name", medicalRecord.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "Name", medicalRecord.PatientID);
            return View(medicalRecord);
        }

        // GET: MedicalRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            if (medicalRecord == null)
            {
                return NotFound();
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Name", medicalRecord.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "Name", medicalRecord.PatientID);
            return View(medicalRecord);
        }

        // POST: MedicalRecord/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedicalRecordID,Date,DoctorID,PatientID,PatientCondition,Indications")] MedicalRecord medicalRecord)
        {
            if (id != medicalRecord.MedicalRecordID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicalRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicalRecordExists(medicalRecord.MedicalRecordID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorID"] = new SelectList(_context.Doctor, "DoctorID", "Name", medicalRecord.DoctorID);
            ViewData["PatientID"] = new SelectList(_context.Patient, "PatientID", "Name", medicalRecord.PatientID);
            return View(medicalRecord);
        }

        // GET: MedicalRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicalRecord = await _context.MedicalRecord
                .Include(m => m.Doctor)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.MedicalRecordID == id);
            if (medicalRecord == null)
            {
                return NotFound();
            }

            return View(medicalRecord);
        }

        // POST: MedicalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicalRecord = await _context.MedicalRecord.FindAsync(id);
            _context.MedicalRecord.Remove(medicalRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicalRecordExists(int id)
        {
            return _context.MedicalRecord.Any(e => e.MedicalRecordID == id);
        }
    }
}
