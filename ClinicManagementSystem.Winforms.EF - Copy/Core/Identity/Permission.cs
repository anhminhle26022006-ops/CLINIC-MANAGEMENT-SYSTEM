namespace CMS.Core.Identity
{
    public static class Permission
    {
        public const string ManageUsers = "MANAGE_USERS";

        public const string ManageAppointments = "MANAGE_APPOINTMENTS";

        public const string ManagePatients = "MANAGE_PATIENTS";

        public const string ViewMedicalRecord = "VIEW_MEDICAL_RECORD";

        public const string EditMedicalRecord = "EDIT_MEDICAL_RECORD";

        public const string CreatePrescription = "CREATE_PRESCRIPTION";

        public const string DispenseMedicine = "DISPENSE_MEDICINE";

        public const string CreateLabRequest = "CREATE_LAB_REQUEST";

        public const string CreateImagingRequest = "CREATE_IMAGING_REQUEST";

        public const string ProcessPayment = "PROCESS_PAYMENT";

        public const string ViewReports = "VIEW_REPORTS";
    }
}