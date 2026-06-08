using System;

namespace CMS.Core.Identity
{
    public static class RoleNormalizer
    {
        public static string Normalize(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return string.Empty;
            }

            string value = role.Trim();
            if (value.Equals(Role.Admin, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Quản trị viên", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Admin;
            }

            if (value.Equals(Role.Doctor, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Bác sĩ", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Bac si", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Doctor;
            }

            if (value.Equals(Role.Nurse, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Y tá", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Y ta", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Nurse;
            }

            if (value.Equals(Role.Pharmacist, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Dược sĩ", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Duoc si", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Pharmacist;
            }

            if (value.Equals(Role.Receptionist, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Lễ tân", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Le tan", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Receptionist;
            }

            if (value.Equals(Role.Technician, StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Kỹ thuật viên", StringComparison.OrdinalIgnoreCase) ||
                value.Equals("Ky thuat vien", StringComparison.OrdinalIgnoreCase))
            {
                return Role.Technician;
            }

            return value;
        }
    }
}
