using AutoMapper;
using HastaneRandevuSistemiAPI.Models.Dto.Appointment.Request;
using HastaneRandevuSistemiAPI.Models.Dto;
using HastaneRandevuSistemiAPI.Models.Entities;
using HastaneRandevuSistemiAPI.Models.Dto.Doctor.Request;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Response;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Appointment Mappings
        CreateMap<AddAppointmentRequestDto, Appointment>();
        CreateMap<Appointment, AppointmentResponseDto>();

        // Doctor Mappings
        CreateMap<AddDoctorRequestDto, Doctor>();
        CreateMap<Doctor, DoctorResponseDto>();

        // Patient Mappings
        CreateMap<AddPatientRequestDto, Patient>();
        CreateMap<Patient, PatientResponseDto>();
    }
}
