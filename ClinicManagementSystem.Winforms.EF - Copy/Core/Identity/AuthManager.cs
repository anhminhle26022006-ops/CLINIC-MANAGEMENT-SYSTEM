using CMS.Core.Constants;
using CMS.Core.Session;

namespace CMS.Core.Identity
{
    public static class AuthManager
    {
        public static bool IsAdmin()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Admin;

        public static bool IsDoctor()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Doctor;

        public static bool IsReceptionist()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Receptionist;

        public static bool IsNurse()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Nurse;

        public static bool IsPharmacist()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Pharmacist;

        public static bool IsTechnician()
            => RoleNormalizer.Normalize(UserSession.RoleName) == Role.Technician;

        // 7 chuyên khoa

        public static bool IsGeneralDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.General;

        public static bool IsPediatricDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.Pediatric;

        public static bool IsObstetricDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.Obstetric;

        public static bool IsENTDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.ENT;

        public static bool IsDentalDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.Dental;

        public static bool IsDermatologyDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.Dermatology;

        public static bool IsEyeDoctor()
            => IsDoctor()
            && UserSession.DepartmentName == DepartmentName.Ophthalmology;
    }
}
