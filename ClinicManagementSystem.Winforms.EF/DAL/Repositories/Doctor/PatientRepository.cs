using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.DataContext;
using DAL.Models;
using DTO;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces.Doctor;

namespace DAL.Repositories.Doctor
{
    public class PatientRepository : IPatientRepository
    {
        private readonly CMSDbContext _context;

        public PatientRepository(CMSDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ApiPatientDTO>> GetAllAsync()
        {
            var patients = await _context.Patients
                .Select(p => new ApiPatientDTO
                {
                    LegacyPatientUuid = p.PatientUuid,
                    PatientCode = p.PatientCode,
                    FullName = p.FullName,
                    Gender = p.Gender ?? "",
                    DOB = p.Dob.HasValue ? p.Dob.Value.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd") : "",
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                })
                .ToListAsync();

            return patients;
        }

        public async Task<ApiPatientDTO> GetByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var patient = await _context.Patients
                .Where(p => p.PatientCode == code.Trim())
                .Select(p => new ApiPatientDTO
                {
                    LegacyPatientUuid = p.PatientUuid,
                    PatientCode = p.PatientCode,
                    FullName = p.FullName,
                    Gender = p.Gender ?? "",
                    DOB = p.Dob.HasValue ? p.Dob.Value.ToDateTime(TimeOnly.MinValue).ToString("yyyy-MM-dd") : "",
                    Phone = p.Phone ?? "",
                    Address = p.Address ?? "",
                    BloodType = p.BloodType ?? "",
                    Allergy = p.Allergy ?? ""
                })
                .FirstOrDefaultAsync();

            return patient;
        }

        public async Task<int?> GetIdByCodeAsync(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return null;

            var id = await _context.Patients
                .Where(p => p.PatientCode == code.Trim())
                .Select(p => (int?)p.PatientId)
                .FirstOrDefaultAsync();

            return id;
        }

        public async Task<ApiPatientDTO> InsertAsync(ApiPatientDTO dto)
        {
            var patient = new Patient
            {
                PatientUuid = dto.LegacyPatientUuid ?? Guid.NewGuid(),
                PatientCode = dto.PatientCode,
                FullName = dto.FullName,
                Gender = string.IsNullOrWhiteSpace(dto.Gender) ? null : dto.Gender,
                Dob = string.IsNullOrWhiteSpace(dto.DOB) ? null : DateOnly.FromDateTime(DateTime.Parse(dto.DOB)),
                Phone = string.IsNullOrWhiteSpace(dto.Phone) ? null : dto.Phone,
                Address = string.IsNullOrWhiteSpace(dto.Address) ? null : dto.Address,
                BloodType = string.IsNullOrWhiteSpace(dto.BloodType) ? null : dto.BloodType,
                Allergy = string.IsNullOrWhiteSpace(dto.Allergy) ? null : dto.Allergy,
                CreatedAt = DateTime.Now
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task<ApiPatientDTO> UpdateAsync(ApiPatientDTO dto)
        {
            var patient = await _context.Patients
                .FirstOrDefaultAsync(p => p.PatientCode == dto.PatientCode);
            if (patient == null)
                throw new InvalidOperationException($"Patient with code {dto.PatientCode} not found");

            // Chỉ cập nhật các trường cho phép; không thay đổi PatientCode và PatientUuid
            patient.FullName = dto.FullName;
            patient.Gender = string.IsNullOrWhiteSpace(dto.Gender) ? null : dto.Gender;
            patient.Dob = string.IsNullOrWhiteSpace(dto.DOB) ? null : DateOnly.FromDateTime(DateTime.Parse(dto.DOB));
            patient.Phone = string.IsNullOrWhiteSpace(dto.Phone) ? null : dto.Phone;
            patient.Address = string.IsNullOrWhiteSpace(dto.Address) ? null : dto.Address;
            patient.BloodType = string.IsNullOrWhiteSpace(dto.BloodType) ? null : dto.BloodType;
            patient.Allergy = string.IsNullOrWhiteSpace(dto.Allergy) ? null : dto.Allergy;

            await _context.SaveChangesAsync();
            return dto;
        }

        public async Task UpsertAsync(ApiPatientDTO dto)
        {
            int? existingId = await GetIdByCodeAsync(dto.PatientCode);
            if (existingId.HasValue)
            {
                await UpdateAsync(dto);
            }
            else
            {
                await InsertAsync(dto);
            }
        }
    }
}