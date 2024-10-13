using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System.Collections.Generic;
using System.Threading.Tasks;
using HastaneRandevuSistemiAPI.Models;

namespace HastaneRandevuSistemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IValidator<AddPatientRequestDto> _patientValidator;

        public PatientController(IPatientService patientService, IValidator<AddPatientRequestDto> patientValidator)
        {
            _patientService = patientService;
            _patientValidator = patientValidator;
        }

        // GET: api/patient 
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Patient>>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(new ApiResponse<List<Patient>>
            {
                Success = true,
                Message = "Patients retrieved successfully.",
                Data = patients
            });
        }

        // GET: api/patient/{id} 
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Patient>>> GetPatientById(string id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound(new ApiResponse<Patient>
                {
                    Success = false,
                    Message = "Patient not found.",
                    Errors = new List<string> { "No patient found with the provided TC." }
                });
            }
            return Ok(new ApiResponse<Patient>
            {
                Success = true,
                Message = "Patient retrieved successfully.",
                Data = patient
            });
        }

        // POST: api/patient 
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Patient>>> CreatePatient([FromBody] AddPatientRequestDto patientDto)
        {
            if (patientDto == null)
            {
                return BadRequest(new ApiResponse<Patient>
                {
                    Success = false,
                    Message = "Patient data is null.",
                    Errors = new List<string> { "Patient data cannot be null." }
                });
            }

            var validationResult = await _patientValidator.ValidateAsync(patientDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<Patient>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                });
            }

            var patient = new Patient
            {
                Tc = patientDto.Tc,
                Name = patientDto.Name,
                // Diğer gerekli alanları burada doldurun. 
            };

            await _patientService.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Tc }, new ApiResponse<Patient>
            {
                Success = true,
                Message = "Patient successfully created.",
                Data = patient
            });
        }

        // PUT: api/patient/{id} 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(string id, [FromBody] Patient patient)
        {
            if (id != patient.Tc)
            {
                return BadRequest(new ApiResponse<Patient>
                {
                    Success = false,
                    Message = "Patient TC mismatch.",
                    Errors = new List<string> { "The TC in the URL does not match the Patient TC." }
                });
            }

            await _patientService.UpdateAsync(patient);
            return NoContent();
        }

        // DELETE: api/patient/{id} 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound(new ApiResponse<Patient>
                {
                    Success = false,
                    Message = "Patient not found.",
                    Errors = new List<string> { "No patient found with the provided TC." }
                });
            }

            await _patientService.DeleteAsync(patient);
            return NoContent();
        }
    }
}
