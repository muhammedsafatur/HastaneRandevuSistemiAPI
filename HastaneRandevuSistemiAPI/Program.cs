using FluentValidation;
using HastaneRandevuSistemiAPI.Contexts;
using HastaneRandevuSistemiAPI.DataAccesLayer.Concrete;
using HastaneRandevuSistemiAPI.Models.Dto.Appointment.Request;
using HastaneRandevuSistemiAPI.Models.Dto.Doctor.Request;
using HastaneRandevuSistemiAPI.Models.Dto.Patient.Request;
using HastaneRandevuSistemiAPI.Repositories.Abstract;
using HastaneRandevuSistemiAPI.ServiceLayer.Abstracts;
using HastaneRandevuSistemiAPI.ServiceLayer.Concretes;
using HastaneRandevuSistemiAPI.Validation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DbContext with SQL Server
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Register repositories and services
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>(); // DoctorService'i eklemeyi unutmayýn.


// Register validators
builder.Services.AddTransient<IValidator<AddPatientRequestDto>, PatientValidator>();
builder.Services.AddTransient<IValidator<AddDoctorRequestDto>, DoctorValidator>();
builder.Services.AddTransient<IValidator<AddAppointmentRequestDto>, AppointmentValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
