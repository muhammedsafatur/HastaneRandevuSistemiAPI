using HastaneRandevuSistemiAPI.Models.Dto.Doctor.Request;
using HastaneRandevuSistemiAPI.Models.Entities;
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
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IValidator<AddDoctorRequestDto> _addDoctorValidator;

        public DoctorController(IDoctorService doctorService, IValidator<AddDoctorRequestDto> addDoctorValidator)
        {
            _doctorService = doctorService;
            _addDoctorValidator = addDoctorValidator;
        }

        // GET: api/doctor
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Doctor>>>> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(new ApiResponse<List<Doctor>>
            {
                Success = true,
                Message = "Doctors retrieved successfully.",
                Data = doctors
            });
        }

        // GET: api/doctor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Doctor>>> GetDoctorById(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound(new ApiResponse<Doctor>
                {
                    Success = false,
                    Message = "Doctor not found.",
                    Errors = new List<string> { "No doctor found with the provided ID." }
                });
            }
            return Ok(new ApiResponse<Doctor>
            {
                Success = true,
                Message = "Doctor retrieved successfully.",
                Data = doctor
            });
        }

        // POST: api/doctor
        [HttpPost]
        public async Task<ActionResult<ApiResponse<Doctor>>> CreateDoctor([FromBody] AddDoctorRequestDto doctorDto)
        {
            if (doctorDto == null)
            {
                return BadRequest(new ApiResponse<Doctor>
                {
                    Success = false,
                    Message = "Doctor data is null.",
                    Errors = new List<string> { "Doctor data cannot be null." }
                });
            }

            var validationResult = await _addDoctorValidator.ValidateAsync(doctorDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<Doctor>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                });
            }

            var doctor = new Doctor
            {
                Id = doctorDto.Id, // Eğer ID otomatik oluşturulacaksa burada Guid.NewGuid() gibi bir işlem yapılabilir
                Name = doctorDto.Name,
                Branch = doctorDto.Branch,
                Role = doctorDto.Role
            };

            await _doctorService.AddAsync(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, new ApiResponse<Doctor>
            {
                Success = true,
                Message = "Doctor successfully created.",
                Data = doctor
            });
        }

        // PUT: api/doctor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return BadRequest(new ApiResponse<Doctor>
                {
                    Success = false,
                    Message = "Doctor ID mismatch.",
                    Errors = new List<string> { "The ID in the URL does not match the Doctor ID." }
                });
            }

            await _doctorService.UpdateAsync(doctor);
            return NoContent();
        }

        // DELETE: api/doctor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);
            if (doctor == null)
            {
                return NotFound(new ApiResponse<Doctor>
                {
                    Success = false,
                    Message = "Doctor not found.",
                    Errors = new List<string> { "No doctor found with the provided ID." }
                });
            }

            await _doctorService.DeleteAsync(doctor);
            return NoContent();
        }
    }
}
