using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // Get All Doctors
        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        // Get Doctor by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            return Ok(doctor);
        }

        // Create a new doctor
        [HttpPost]
        public async Task<ActionResult> AddDoctor([FromBody] Doctor doctor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorService.AddDoctorAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        // Update an existing doctor
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id)
                return BadRequest("Doctor ID does not match.");

            var existingDoctor = await _doctorService.GetDoctorByIdAsync(id);
            if (existingDoctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            await _doctorService.UpdateDoctorAsync(doctor);
            return NoContent();
        }

        // Delete a doctor
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(id);
            if (doctor == null)
                return NotFound($"Doctor with ID {id} not found.");

            await _doctorService.DeleteDoctorAsync(id);
            return NoContent();
        }

        // Get all patients for a specific doctor
        [HttpGet("{doctorId}/patients")]
        public async Task<IActionResult> GetAllPatientsByDoctor(int doctorId)
        {
            var patients = await _doctorService.GetAllPatientsAsync(doctorId);
            if (patients == null || patients.Count == 0)
            {
                return NotFound($"No patients found for doctor with ID {doctorId}");
            }
            return Ok(patients);
        }
    }
}
