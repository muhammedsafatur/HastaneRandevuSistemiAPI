using HastaneRandevuSistemiAPI.Models;
using HastaneRandevuSistemiAPI.Models.Dto.Appointment.Request;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IValidator<AddAppointmentRequestDto> _addAppointmentValidator;

        public AppointmentController(IAppointmentService appointmentService, IValidator<AddAppointmentRequestDto> addAppointmentValidator)
        {
            _appointmentService = appointmentService;
            _addAppointmentValidator = addAppointmentValidator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAppointment([FromBody] AddAppointmentRequestDto appointmentDto)
        {
            if (appointmentDto == null)
            {
                return BadRequest(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Appointment cannot be null.",
                    Errors = new List<string> { "Appointment data cannot be null." }
                });
            }

            var validationResult = await _addAppointmentValidator.ValidateAsync(appointmentDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Validation failed.",
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList()
                });
            }

            // Randevu tarihi kontrolü
            var existingAppointments = await _appointmentService.GetByDoctorIdAsync(appointmentDto.DoctorId);
            if (existingAppointments.Count >= 10)
            {
                return BadRequest(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Doctor can have a maximum of 10 appointments.",
                    Errors = new List<string> { "Doctor has reached the maximum number of appointments." }
                });
            }

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(), // ID'yi otomatik oluştur
                AppointmentDate = appointmentDto.AppointmentDate,
                DoctorId = appointmentDto.DoctorId,
                PatientTc = appointmentDto.PatientTc
            };

            await _appointmentService.AddAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.Id }, new ApiResponse<Appointment>
            {
                Success = true,
                Message = "Appointment successfully created.",
                Data = appointment
            });
        }


        [HttpPost("cleanup-old-appointments")]
        public async Task<IActionResult> CleanupOldAppointments()
        {
            await _appointmentService.CleanupOldAppointmentsAsync();
            return Ok("Old appointments cleaned up successfully.");
        }


        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Appointment not found.",
                    Errors = new List<string> { "No appointment found with the provided ID." }
                });
            }
            return Ok(new ApiResponse<Appointment>
            {
                Success = true,
                Message = "Appointment retrieved successfully.",
                Data = appointment
            });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Appointment not found.",
                    Errors = new List<string> { "No appointment found with the provided ID." }
                });
            }

            await _appointmentService.DeleteAsync(appointment);
            return NoContent();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAppointment([FromBody] AddAppointmentRequestDto updateAppointmentDto)
        {
            if (updateAppointmentDto == null)
            {
                return BadRequest(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Update appointment data cannot be null.",
                    Errors = new List<string> { "Appointment data cannot be null." }
                });
            }

            var existingAppointment = await _appointmentService.GetByIdAsync(updateAppointmentDto.Id);
            if (existingAppointment == null)
            {
                return NotFound(new ApiResponse<Appointment>
                {
                    Success = false,
                    Message = "Appointment not found.",
                    Errors = new List<string> { "No appointment found with the provided ID." }
                });
            }

            // Randevu güncelleme işlemi
            existingAppointment.AppointmentDate = updateAppointmentDto.AppointmentDate;
            existingAppointment.DoctorId = updateAppointmentDto.DoctorId;
            existingAppointment.PatientTc = updateAppointmentDto.PatientTc;

            await _appointmentService.UpdateAsync(existingAppointment);

            return Ok(new ApiResponse<Appointment>
            {
                Success = true,
                Message = "Appointment successfully updated.",
                Data = existingAppointment
            });
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAsync(); 
            return Ok(new ApiResponse<IEnumerable<Appointment>>
            {
                Success = true,
                Message = "Appointments retrieved successfully.",
                Data = appointments
            });
        }
                            
    }
}
