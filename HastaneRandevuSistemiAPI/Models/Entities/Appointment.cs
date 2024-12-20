﻿using HastaneRandevuSistemiAPI.Models.Entities.Enums;
using HastaneRandevuSistemiAPI.Models.Entities;

public class Appointment : Entity<Guid>
{


    public int DoctorId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public Doctor? Doctor { get; set; }
    public string? Title { get; set; }
    public Branch Branch { get; set; }
    public string? PatientTc { get; set; }
    public Patient? Patient { get; set; }
}
