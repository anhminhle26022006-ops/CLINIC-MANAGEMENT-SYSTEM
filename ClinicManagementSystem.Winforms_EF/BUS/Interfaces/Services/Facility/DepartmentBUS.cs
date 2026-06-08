using System;
using System.Collections.Generic;
using System.Linq;
using BUS.Interfaces;
using DAL.Repositories;
using DTO;

namespace BUS.Services
{
    public class DepartmentBUS : IDepartmentBUS
    {
        private readonly DepartmentDAL _dal = new DepartmentDAL();

        public List<DepartmentDTO> GetAll() => _dal.GetAll();
        public DepartmentDTO GetById(int id) => _dal.GetById(id);
        public bool Exists(int id) => _dal.Exists(id);

        public bool Add(DepartmentDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.DepartmentName))
                throw new ArgumentException("Tên chuyên khoa không được để trống.");
            if (dto.DepartmentName.Trim().Length > 100)
                throw new ArgumentException("Tên chuyên khoa không được quá 100 ký tự.");
            if (_dal.NameExists(dto.DepartmentName))
                throw new InvalidOperationException($"Chuyên khoa '{dto.DepartmentName.Trim()}' đã tồn tại.");
            return _dal.Add(dto);
        }

        public bool Update(DepartmentDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));
            if (dto.DepartmentID <= 0) throw new ArgumentException("ID chuyên khoa không hợp lệ.");
            if (string.IsNullOrWhiteSpace(dto.DepartmentName))
                throw new ArgumentException("Tên chuyên khoa không được để trống.");
            if (_dal.NameExists(dto.DepartmentName, dto.DepartmentID))
                throw new InvalidOperationException($"Tên chuyên khoa '{dto.DepartmentName.Trim()}' đã được dùng.");
            return _dal.Update(dto);
        }

        public bool Delete(int id)
        {
            if (id <= 0) throw new ArgumentException("ID chuyên khoa không hợp lệ.");
            return _dal.Delete(id);
        }

        public List<DepartmentDTO> Search(string keyword)
        {
            var all = _dal.GetAll();
            if (string.IsNullOrWhiteSpace(keyword)) return all;
            keyword = keyword.ToLower();
            return all.Where(d =>
                (d.DepartmentName ?? "").ToLower().Contains(keyword) ||
                (d.Description ?? "").ToLower().Contains(keyword)).ToList();
        }
    }
}