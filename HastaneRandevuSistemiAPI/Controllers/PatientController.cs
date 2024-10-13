using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // Get All Patients
        [HttpGet]
        public async Task<ActionResult<List<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        // Get Patient by TC
        [HttpGet("{tc}")]
        public async Task<ActionResult<Patient>> GetPatientByTc(string tc)
        {
            var patient = await _patientService.GetPatientByTcAsync(tc);
            if (patient == null)
                return NotFound($"Patient with TC {tc} not found.");

            return Ok(patient);
        }

        // Create a new patient
        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _patientService.AddPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatientByTc), new { tc = patient.Tc }, patient);
        }

        // Update an existing patient
        [HttpPut("{tc}")]
        public async Task<ActionResult> UpdatePatient(string tc, [FromBody] Patient patient)
        {
            if (tc != patient.Tc)
                return BadRequest("TC number does not match.");

            var existingPatient = await _patientService.GetPatientByTcAsync(tc);
            if (existingPatient == null)
                return NotFound($"Patient with TC {tc} not found.");

            await _patientService.UpdatePatientAsync(patient);
            return NoContent();
        }

        // Delete a patient
        [HttpDelete("{tc}")]
        public async Task<ActionResult> DeletePatient(string tc)
        {
            var patient = await _patientService.GetPatientByTcAsync(tc);
            if (patient == null)
                return NotFound($"Patient with TC {tc} not found.");

            await _patientService.DeletePatientAsync(tc);
            return NoContent();
        }
    }
}
