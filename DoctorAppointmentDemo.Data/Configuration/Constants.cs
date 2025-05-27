namespace MyDoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        // заменить на путь валидный для вашей директории на пк (в будущем будем использовать относительный путь)
        public const string AppSettingsPath = "C:\\Users\\admin\\source\\repos\\DoctorAppointmentDemo\\DoctorAppointmentDemo.Data\\Configuration\\appsettings.json";

        public static readonly string AppSettingsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\Configuration\", "appsettings.json"));
        public static readonly string DoctorsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "doctors.json"));
        public static readonly string PatientsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "patients.json"));
        public static readonly string AppointmentsPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\..\DoctorAppointmentDemo.Data\MockedDatabase\", "appointments.json"));
    }
}
