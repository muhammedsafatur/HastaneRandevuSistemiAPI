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
        CreateMap<AddAppointmentRequestDto, Appointment>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid())); // ID'yi otomatik oluştur
        CreateMap<Appointment, AppointmentResponseDto>();

        // Doctor Mappings
        CreateMap<AddDoctorRequestDto, Doctor>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0)); // ID ataması yapılabilir
        CreateMap<Doctor, DoctorResponseDto>();

        // Patient Mappings
        CreateMap<AddPatientRequestDto, Patient>();
        CreateMap<Patient, PatientResponseDto>();
    }
}
