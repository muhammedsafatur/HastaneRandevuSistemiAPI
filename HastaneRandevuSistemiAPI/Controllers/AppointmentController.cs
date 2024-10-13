using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HastaneRandevuSistemiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // Add a new appointment
        [HttpPost]
        public async Task<IActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
                return BadRequest("Appointment cannot be null.");

            await _appointmentService.AddAppointmentAsync(appointment);
            return Ok("Appointment added successfully.");
        }

        // Get appointment by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(Guid id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
                return NotFound($"Appointment with ID {id} not found.");

            return Ok(appointment);
        }

        // Get all appointments
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        // Update an appointment
        [HttpPut("UpdateAppointment{id}")]
        public async Task<IActionResult> UpdateAppointment(Guid id, [FromBody] Appointment appointment)
        {
            if (appointment == null || appointment.Id != id)
                return BadRequest("Invalid appointment data.");

            await _appointmentService.UpdateAppointmentAsync(appointment);
            return Ok("Appointment updated successfully.");
        }

        // Delete an appointment
        [HttpDelete("DeleteAppointment{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            await _appointmentService.DeleteAppointmentAsync(id);
            return Ok("Appointment deleted successfully.");
        }

        // Get appointments by doctor ID
        [HttpGet("GetAppointmentsByDoctorId/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(int doctorId)
        {
            var appointments = await _appointmentService.GetByDoctorIdAsync(doctorId);
            if (appointments == null || appointments.Count == 0)
                return NotFound($"No appointments found for doctor with ID {doctorId}.");

            return Ok(appointments);
        }

        // Get appointments by date
        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAppointmentsByDate(DateTime date)
        {
            var appointments = await _appointmentService.GetByDateAsync(date);
            if (appointments == null || appointments.Count == 0)
                return NotFound($"No appointments found on date {date.ToShortDateString()}.");

            return Ok(appointments);
        }
    }
}
